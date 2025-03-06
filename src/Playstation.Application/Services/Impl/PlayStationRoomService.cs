using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Playstation.Application.Models;
using Playstation.Application.Models.Console;
using Playstation.Domain.Entity;
using Playstation.Infrastructure.Persistence;

namespace Playstation.Application.Services.Impl
{
    public class PlayStationRoomService : IPlayStationRoomService
    {
        private readonly IMapper _mapper;
        private readonly PlayStationDbContext _dbContext;

        public PlayStationRoomService(IMapper mapper, PlayStationDbContext context)
        {
            _mapper = mapper;
            _dbContext = context;
        }

        public async Task<ApiResult<PlayStationRoomCMResponce>> CreatePlayStationRoomAsync(PlayStationRoomCM model)
        {
            var gamesconsole = _mapper.Map<PlayStationRoom>(model);
            gamesconsole.CreatedOn = DateTime.UtcNow;

            _dbContext.PlayStationRooms.Add(gamesconsole);
            await _dbContext.SaveChangesAsync();

            return ApiResult<PlayStationRoomCMResponce>.Success(new PlayStationRoomCMResponce
            {
                Id = gamesconsole.Id
            });
        }

        public async Task<ApiResult<bool>> DeletePlayStationRoomAsync(Guid id)
        {
            var gamesconsole = _dbContext.PlayStationRooms.FirstOrDefault(t => t.Id == id);
            if (gamesconsole == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "PlayStationRooms not found" });
            }

            _dbContext.PlayStationRooms.Remove(gamesconsole);

            await _dbContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<IEnumerable<PlayStationRoomRM>>> GetAllPlayStationRoomAsync()
        {
            var gamesconsole = await _dbContext.PlayStationRooms
                                           .AsNoTracking()
                                           .ProjectTo<PlayStationRoomRM>(_mapper.ConfigurationProvider)
                                           .ToListAsync();


            return ApiResult<IEnumerable<PlayStationRoomRM>>.Success(gamesconsole);
        }

        public async Task<ApiResult<PlayStationRoomRM>> GetByIdPlayStationRoomAsync(Guid id)
        {
            var gamesconsole = await _dbContext.PlayStationRooms
            .AsNoTracking()
            .ProjectTo<PlayStationRoomRM>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(c => c.Id == id);

            if (gamesconsole == null)
            {
                return ApiResult<PlayStationRoomRM>.Failure(new List<string> { "PlayStationRooms not found" });
            }

            return ApiResult<PlayStationRoomRM>.Success(gamesconsole);
        }

        public async Task<ApiResult<PlayStationRoomUMResponce>> UpdatePlayStationRoomAsync(PlayStationRoomUM model)
        {
            var gamesconsole = await _dbContext.PlayStationRooms.FirstOrDefaultAsync(s => s.Id == model.Id);

            if (gamesconsole == null)
            {
                return ApiResult<PlayStationRoomUMResponce>.Failure(new List<string> { "PlayStationRooms not found" });
            }

            _mapper.Map(model, gamesconsole);
            gamesconsole.UpdatedOn = DateTime.Now;
            _dbContext.PlayStationRooms.Update(gamesconsole);
            await _dbContext.SaveChangesAsync();

            return ApiResult<PlayStationRoomUMResponce>.Success(new PlayStationRoomUMResponce
            {
                Id = gamesconsole.Id,
            });
        }
    }
}
