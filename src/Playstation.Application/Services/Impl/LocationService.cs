using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Playstation.Application.Models;
using Playstation.Application.Models.Location;
using Playstation.Domain.Entity;
using Playstation.Infrastructure.Persistence;

namespace Playstation.Application.Services.Impl
{
    public class LocationService : ILocationService
    {
        private readonly IMapper _mapper;
        private readonly PlayStationDbContext _dbContext;

        public LocationService(IMapper mapper, PlayStationDbContext context)
        {
            _mapper = mapper;
            _dbContext = context;
        }

        public async Task<ApiResult<LocationCMResponce>> CreateLocationAsync(LocationCM model)
        {
            var location = _mapper.Map<Location>(model);
            location.CreatedOn = DateTime.UtcNow;

            _dbContext.Locations.Add(location);
            await _dbContext.SaveChangesAsync();

            return ApiResult<LocationCMResponce>.Success(new LocationCMResponce
            {
                Id = location.Id
            });
        }

        public async Task<ApiResult<bool>> DeleteLocationAsync(Guid id)
        {
            var location = _dbContext.Locations.FirstOrDefault(t => t.Id == id);
            if (location == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "Location not found" });
            }

            _dbContext.Locations.Remove(location);

            await _dbContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<IEnumerable<LocationRM>>> GetAllLocationAsync()
        {
            var location = await _dbContext.Locations
                                            .AsNoTracking()
                                            .ProjectTo<LocationRM>(_mapper.ConfigurationProvider)
                                            .ToListAsync();


            return ApiResult<IEnumerable<LocationRM>>.Success(location);
        }

        public async Task<ApiResult<LocationRM>> GetByIdLocationAsync(Guid id)
        {
            var location = await _dbContext.Locations
            .AsNoTracking()
            .ProjectTo<LocationRM>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(c => c.Id == id);

            if (location == null)
            {
                return ApiResult<LocationRM>.Failure(new List<string> { "Location not found" });
            }

            return ApiResult<LocationRM>.Success(location);
        }

        public async Task<ApiResult<LocationUMResponce>> UpdateLocationAsync(LocationUM model)
        {
            var games = await _dbContext.Locations.FirstOrDefaultAsync(s => s.Id == model.Id);

            if (games == null)
            {
                return ApiResult<LocationUMResponce>.Failure(new List<string> { "Location not found" });
            }

            _mapper.Map(model, games);
            games.UpdatedOn = DateTime.Now;
            _dbContext.Locations.Update(games);
            await _dbContext.SaveChangesAsync();

            return ApiResult<LocationUMResponce>.Success(new LocationUMResponce
            {
                Id = games.Id,
            });
        }
    }
}
