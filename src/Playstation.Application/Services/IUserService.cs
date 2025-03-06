using Playstation.Application.Models;
using Playstation.Application.Models.User;

namespace Playstation.Application.Services;

public interface IUserService
{
    Task<ApiResult<CreateUserResponseModel>> SignUpAsync(CreateUserModel createUserModel);
    Task<ApiResult<bool>> SendOtpCode(Guid userId);
    Task<ApiResult<bool>> ResendOtpCode(Guid userId);
    Task<ApiResult<bool>> VerifyOtpAsync(string code, Guid userId);
    Task<ApiResult<LoginResponseModel>> LoginAsync(LoginUserModel loginModel);
    Task<ApiResult<string>> ValidateAndRefreshToken(Guid id, string refreshToken);
}

