using Playstation.Application.Models;
using Playstation.Application.Models.Game;

namespace Playstation.Application.Services
{
    public interface IGameService
    {
        Task<ApiResult<GameCMResponce>> CreateGameAsync(GameCM model);
        Task<ApiResult<GameRM>> GetByIdGameAsync(Guid id);
        Task<ApiResult<IEnumerable<GameRM>>> GetAllGameAsync();
        Task<ApiResult<GameUMResponce>> UpdateGameAsync(GameUM model);
        Task<ApiResult<bool>> DeleteGameAsync(Guid id);
    }
}
