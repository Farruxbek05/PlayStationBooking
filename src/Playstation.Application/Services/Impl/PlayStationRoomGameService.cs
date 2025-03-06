using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Playstation.Application.Models;
using Playstation.Application.Models.PlayStationRoomGame;
using Playstation.Domain.Entity;
using Playstation.Infrastructure.Persistence;

namespace Playstation.Application.Services.Impl;

public class PlayStationRoomGameService : IPlayStationRoomGameService
{
    private readonly IMapper _mapper;
    private readonly PlayStationDbContext _dbContext;

    public PlayStationRoomGameService(IMapper mapper, PlayStationDbContext context)
    {
        _mapper = mapper;
        _dbContext = context;
    }

    public async Task<ApiResult<PlayStationRoomGameCMResponc>> CreatePlayStationRoomGameAsync(PlayStationRoomGameCM model)
    {
        var psroomgame = _mapper.Map<PlayStationRoomGame>(model);
        psroomgame.CreatedOn = DateTime.UtcNow;

        _dbContext.PlayStationRoomGames.Add(psroomgame);
        await _dbContext.SaveChangesAsync();

        return ApiResult<PlayStationRoomGameCMResponc>.Success(new PlayStationRoomGameCMResponc
        {
            Id = psroomgame.Id
        });
    }

    public async Task<ApiResult<bool>> DeletePlayStationRoomGameAsync(Guid id)
    {
        var psroomgame = _dbContext.PlayStationRoomGames.FirstOrDefault(t => t.Id == id);
        if (psroomgame == null)
        {
            return ApiResult<bool>.Failure(new List<string> { "PlayStationRoomGame not found" });
        }

        _dbContext.PlayStationRoomGames.Remove(psroomgame);

        await _dbContext.SaveChangesAsync();

        return ApiResult<bool>.Success(true);
    }

    public async Task<ApiResult<IEnumerable<PlayStationRoomGameRM>>> GetAllPlayStationRoomGameAsync()
    {
        var psroomgame = await _dbContext.PlayStationRoomGames
                                          .AsNoTracking()
                                          .ProjectTo<PlayStationRoomGameRM>(_mapper.ConfigurationProvider)
                                          .ToListAsync();


        return ApiResult<IEnumerable<PlayStationRoomGameRM>>.Success(psroomgame);
    }

    public async Task<ApiResult<PlayStationRoomGameRM>> GetByIdPlayStationRoomGameAsync(Guid id)
    {
        var psroomgame = await _dbContext.PlayStationRoomGames
           .AsNoTracking()
           .ProjectTo<PlayStationRoomGameRM>(_mapper.ConfigurationProvider)
           .FirstOrDefaultAsync(c => c.Id == id);

        if (psroomgame == null)
        {
            return ApiResult<PlayStationRoomGameRM>.Failure(new List<string> { "PlayStationRoomGame not found" });
        }

        return ApiResult<PlayStationRoomGameRM>.Success(psroomgame);
    }

    public async Task<ApiResult<PlayStationRoomGameUMResponce>> UpdatePlayStationRoomGameAsync(PlayStationRoomGameUM model)
    {
        var psroomgame = await _dbContext.PlayStationRoomGames.FirstOrDefaultAsync(s => s.Id == model.Id);

        if (psroomgame == null)
        {
            return ApiResult<PlayStationRoomGameUMResponce>.Failure(new List<string> { "PlayStationRoomGame not found" });
        }

        _mapper.Map(model, psroomgame);
        psroomgame.UpdatedOn = DateTime.Now;
        _dbContext.PlayStationRoomGames.Update(psroomgame);
        await _dbContext.SaveChangesAsync();

        return ApiResult<PlayStationRoomGameUMResponce>.Success(new PlayStationRoomGameUMResponce
        {
            Id = psroomgame.Id,
        });
    }
}
