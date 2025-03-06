﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Playstation.Application.Helpers;
using Playstation.Application.Helpers.GenerateJwt;
using Playstation.Application.Helpers.PasswordHashers;
using Playstation.Application.Models;
using Playstation.Application.Models.User;
using Playstation.Application.Models.Validators.User;
using Playstation.Domain.Entity;
using Playstation.Infrastructure.Persistence;

namespace Playstation.Application.Services.Impl;
public class UserService : IUserService
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly ILogger<UserService> _logger;
    private readonly PlayStationDbContext databaseContext;
    public readonly PlayStationDbContext _dbContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenHandler _jwtTokenHandler;
    private readonly IEmailService _emailService;
    private readonly UserSettings _userSettings;

    public UserService(IMapper mapper,
        IConfiguration configuration,
        ILogger<UserService> logger,
        PlayStationDbContext dbContext,
        IPasswordHasher passwordHasher,
        IJwtTokenHandler jwtTokenHandler,
        IEmailService emailService,
        IOptions<UserSettings> userSettings)
    {
        _mapper = mapper;
        _logger = logger;
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _jwtTokenHandler = jwtTokenHandler;
        _emailService = emailService;
        _userSettings = userSettings.Value;
    }

    public async Task<ApiResult<CreateUserResponseModel>> SignUpAsync(CreateUserModel createUserModel)
    {
        var validationResult = new CreateUserModelValidator(_dbContext)
           .Validate(createUserModel);

        if (!validationResult.IsValid)
        {
            return ApiResult<CreateUserResponseModel>
                    .Failure(validationResult.Errors
                        .Select(a => a.ErrorMessage));
        }

        var user = _mapper.Map<User>(createUserModel);

        string randomSalt = Guid.NewGuid().ToString();

        user.Role = UserRole.User;
        user.Salt = randomSalt;
        user.PasswordHash = _passwordHasher.Encrypt(createUserModel.Password, randomSalt);
        user.FullName = $"{user.Firstname} {user.Lastname}";
        user.Status = UserStatus.New;
        user.CreatedOn = DateTime.Now;

        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var session = new UserSession(Guid.NewGuid().ToString(), user.Id);
            var createdUserSessionId = await _dbContext.UserSessions.AddAsync(session);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.InnerException?.Message, "Error occurred while creating user");
            await transaction.RollbackAsync();
            return ApiResult<CreateUserResponseModel>.Failure(errors: new List<string> { ex.InnerException?.Message });
        }

        await transaction.CommitAsync();

        return ApiResult<CreateUserResponseModel>.Success(new CreateUserResponseModel
        {
            Id = user.Id
        });
    }


    public async Task<ApiResult<string>> ValidateAndRefreshToken(Guid id, string refreshToken)
    {
        var user = await _dbContext.Users.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
        {
            return ApiResult<string>.Failure(new List<string> { "User not found" });
        }

        if (user.RefreshToken != refreshToken)
        {
            return ApiResult<string>.Failure(new List<string> { "Invalid refresh token" });
        }

        if (user.RefreshTokenExpireDate < DateTime.Now)
        {
            return ApiResult<string>.Failure(new List<string> { "Unauthorized" });
        }

        return ApiResult<string>.Success(_jwtTokenHandler.GenerateAccessToken(user, refreshToken));
    }

    public async Task<ApiResult<bool>> SendOtpCode(Guid userId)
    {
        var maybeUser = await _dbContext.Users
            .Include(a => a.OtpCodes)
            .FirstOrDefaultAsync(a => a.Id == userId);

        if (maybeUser == null)
        {
            return ApiResult<bool>.Failure(new List<string> { "User not found" });
        }

        var otpCode = new OtpCode
        {
            Code = OtpCodeHelper.GenerateOtpCode(),
            Status = OtpCodeStatus.Unverified
        };

        maybeUser.OtpCodes.Add(otpCode);

        bool isSent = await _emailService.SendEmailAsync(maybeUser.Email, otpCode.Code);

        if (!isSent)
        {
            return ApiResult<bool>.Failure(new List<string> { "Failed to send OTP email" });
        }

        await _dbContext.SaveChangesAsync();

        return ApiResult<bool>.Success(true);
    }

    public async Task<ApiResult<bool>> ResendOtpCode(Guid userId)
    {
        var user = await _dbContext.Users.Include(a => a.OtpCodes)
            .FirstOrDefaultAsync(a => a.Id == userId);

        if (user == null)
        {
            return ApiResult<bool>.Failure(new List<string> { "User not found" });
        }

        var lastOtp = user.OtpCodes
            .OrderByDescending(otp => otp.CreatedAt)
            .FirstOrDefault();

        if (lastOtp == null)
        {
            return ApiResult<bool>.Failure(new List<string> { "No OTP found to resend" });
        }

        if (!CanResend(lastOtp.CreatedAt))
        {
            var waitTimeSeconds = GetWaitTimeForResend(lastOtp.CreatedAt);
            return ApiResult<bool>.Failure(new List<string>
                { $"Please wait {waitTimeSeconds} seconds before requesting a new code" });
        }

        if (!IsExpired(lastOtp.CreatedAt))
        {
            bool isSent = await _emailService.SendEmailAsync(user.Email, lastOtp.Code);
            if (!isSent)
            {
                return ApiResult<bool>.Failure(new List<string> { "Failed to send OTP email" });
            }
            return ApiResult<bool>.Success(true);
        }

        var newOtpCode = new OtpCode
        {
            Code = OtpCodeHelper.GenerateOtpCode(),
            Status = OtpCodeStatus.Unverified
        };

        user.OtpCodes.Add(newOtpCode);

        bool isSentNew = await _emailService.SendEmailAsync(user.Email, newOtpCode.Code);
        if (!isSentNew)
        {
            return ApiResult<bool>.Failure(new List<string> { "Failed to send OTP email" });
        }

        await _dbContext.SaveChangesAsync();
        return ApiResult<bool>.Success(true);
    }

    public async Task<ApiResult<bool>> VerifyOtpAsync(string code, Guid userId)
    {
        if (string.IsNullOrEmpty(code))
        {
            return ApiResult<bool>.Failure(new List<string> { "OTP code cannot be empty" });
        }

        var user = await _dbContext.Users
            .Include(o => o.OtpCodes)
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            return ApiResult<bool>.Failure(new List<string> { "User not found" });
        }

        var lastOtp = user.OtpCodes
            .Where(otp => otp.Status == OtpCodeStatus.Unverified)
            .OrderByDescending(otp => otp.CreatedAt)
            .FirstOrDefault();

        if (lastOtp == null)
        {
            return ApiResult<bool>.Failure(new List<string> { "No active OTP found" });
        }

        if (IsExpired(lastOtp.CreatedAt))
        {
            lastOtp.Status = OtpCodeStatus.Expired;
            await _dbContext.SaveChangesAsync();
            return ApiResult<bool>.Failure(new List<string> { "OTP has expired" });
        }

        if (lastOtp.Code != code)
        {
            return ApiResult<bool>.Failure(new List<string> { "Invalid OTP code" });
        }

        lastOtp.Status = OtpCodeStatus.Verified;
        await _dbContext.SaveChangesAsync();

        return ApiResult<bool>.Success(true);
    }

    public async Task<ApiResult<LoginResponseModel>> LoginAsync(LoginUserModel loginModel)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(a => a.Email == loginModel.Email);

        if (user == null)
        {
            return ApiResult<LoginResponseModel>.Failure(new List<string> { "User not found" });
        }

        var hashedPassword = _passwordHasher.Encrypt(loginModel.Password, user.Salt);

        if (user.PasswordHash != hashedPassword)
        {
            return ApiResult<LoginResponseModel>.Failure(new List<string> { "Invalid password" });
        }

        var session = new UserSession(Guid.NewGuid().ToString(), user.Id);
        var createdUserSessionId = await _dbContext.UserSessions.AddAsync(session);
        await _dbContext.SaveChangesAsync();

        var accessToken = _jwtTokenHandler.GenerateAccessToken(user, session.Token);
        var refreshToken = _jwtTokenHandler.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpireDate = DateTime.Now.AddDays(_userSettings.RefreshTokenExpirationDays);

        return ApiResult<LoginResponseModel>.Success(new LoginResponseModel
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            Email = user.Email,
            Id = user.Id
        });
    }

    public bool IsExpired(DateTimeOffset createdAt) =>
       createdAt.AddSeconds(_userSettings.OtpExpirationTimeInSeconds) < DateTimeOffset.Now;

    private bool CanResend(DateTimeOffset createdAt) =>
        createdAt.AddSeconds(_userSettings.OtpExpirationTimeInSeconds - _userSettings.OtpResendTimeInSeconds) < DateTimeOffset.Now;

    private int GetWaitTimeForResend(DateTimeOffset createdAt)
    {
        var resendTime = createdAt.AddSeconds(_userSettings.OtpExpirationTimeInSeconds - _userSettings.OtpResendTimeInSeconds);
        var waitTime = resendTime - DateTimeOffset.Now;
        return Math.Max(0, (int)waitTime.TotalSeconds);
    }
}


