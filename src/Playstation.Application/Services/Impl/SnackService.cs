using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Playstation.Application.Models;
using Playstation.Application.Models.Snack;
using Playstation.Domain.Entity;
using Playstation.Infrastructure.Persistence;

namespace Playstation.Application.Services.Impl
{
    public class SnackService : ISnackService
    {

        private readonly IMapper _mapper;
        private readonly PlayStationDbContext _dbContext;

        public SnackService(IMapper mapper, PlayStationDbContext context)
        {
            _mapper = mapper;
            _dbContext = context;
        }

        public async Task<ApiResult<SnackCMResponce>> CreateSnackAsync(SnackCM model)
        {
            var snack = _mapper.Map<Snack>(model);
            snack.CreatedOn = DateTime.UtcNow;

            _dbContext.Snacks.Add(snack);
            await _dbContext.SaveChangesAsync();

            return ApiResult<SnackCMResponce>.Success(new SnackCMResponce
            {
                Id = snack.Id
            });
        }

        public async Task<ApiResult<bool>> DeleteSnackAsync(Guid id)
        {
            var snack = _dbContext.Snacks.FirstOrDefault(t => t.Id == id);
            if (snack == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "Snack not found" });
            }

            _dbContext.Snacks.Remove(snack);

            await _dbContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<IEnumerable<SnackRM>>> GetAllSnackAsync()
        {
            var snack = await _dbContext.Snacks
                                           .AsNoTracking()
                                           .ProjectTo<SnackRM>(_mapper.ConfigurationProvider)
                                           .ToListAsync();


            return ApiResult<IEnumerable<SnackRM>>.Success(snack);
        }

        public async Task<ApiResult<SnackRM>> GetByIdSnackAsync(Guid id)
        {
            var snack = await _dbContext.Snacks
           .AsNoTracking()
           .ProjectTo<SnackRM>(_mapper.ConfigurationProvider)
           .FirstOrDefaultAsync(c => c.Id == id);

            if (snack == null)
            {
                return ApiResult<SnackRM>.Failure(new List<string> { "Snack not found" });
            }

            return ApiResult<SnackRM>.Success(snack);
        }

        public async Task<ApiResult<SnackUMResponce>> UpdateSnackAsync(SnackUM model)
        {
            var snack = await _dbContext.Snacks.FirstOrDefaultAsync(s => s.Id == model.Id);

            if (snack == null)
            {
                return ApiResult<SnackUMResponce>.Failure(new List<string> { "Snack not found" });
            }

            _mapper.Map(model, snack);
            snack.UpdatedOn = DateTime.Now;
            _dbContext.Snacks.Update(snack);
            await _dbContext.SaveChangesAsync();

            return ApiResult<SnackUMResponce>.Success(new SnackUMResponce
            {
                Id = snack.Id,
            });
        }
    }
}
