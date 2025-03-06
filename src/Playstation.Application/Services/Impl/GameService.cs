using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Playstation.Application.Models;
using Playstation.Application.Models.Game;
using Playstation.Domain.Entity;
using Playstation.Infrastructure.Persistence;

namespace Playstation.Application.Services.Impl
{
    public class GameService : IGameService
    {
        private readonly IMapper _mapper;
        private readonly PlayStationDbContext _dbContext;

        public GameService(IMapper mapper, PlayStationDbContext context)
        {
            _mapper = mapper;
            _dbContext = context;
        }

        public async Task<ApiResult<GameCMResponce>> CreateGameAsync(GameCM model)
        {
            var games = _mapper.Map<Game>(model);
            games.CreatedOn = DateTime.UtcNow;

            _dbContext.Games.Add(games);
            await _dbContext.SaveChangesAsync();

            return ApiResult<GameCMResponce>.Success(new GameCMResponce
            {
                Id = games.Id
            });
        }

        public async Task<ApiResult<bool>> DeleteGameAsync(Guid id)
        {
            var games = _dbContext.Games.FirstOrDefault(t => t.Id == id);
            if (games == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "Game not found" });
            }

            _dbContext.Games.Remove(games);

            await _dbContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<IEnumerable<GameRM>>> GetAllGameAsync()
        {
            var games = await _dbContext.Games
                                           .AsNoTracking()
                                           .ProjectTo<GameRM>(_mapper.ConfigurationProvider)
                                           .ToListAsync();


            return ApiResult<IEnumerable<GameRM>>.Success(games);
        }

        public async Task<ApiResult<GameRM>> GetByIdGameAsync(Guid id)
        {
            var games = await _dbContext.Games
            .AsNoTracking()
            .ProjectTo<GameRM>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(c => c.Id == id);

            if (games == null)
            {
                return ApiResult<GameRM>.Failure(new List<string> { "Game not found" });
            }

            return ApiResult<GameRM>.Success(games);
        }

        public async Task<ApiResult<GameUMResponce>> UpdateGameAsync(GameUM model)
        {
            var games = await _dbContext.Games.FirstOrDefaultAsync(s => s.Id == model.Id);

            if (games == null)
            {
                return ApiResult<GameUMResponce>.Failure(new List<string> { "Game not found" });
            }

            _mapper.Map(model, games);
            games.UpdatedOn = DateTime.Now;
            _dbContext.Games.Update(games);
            await _dbContext.SaveChangesAsync();

            return ApiResult<GameUMResponce>.Success(new GameUMResponce
            {
                Id = games.Id,
            });
        }
    }
}

