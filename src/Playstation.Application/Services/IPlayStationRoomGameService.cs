using Playstation.Application.Models;
using Playstation.Application.Models.PlayStationRoomGame;

namespace Playstation.Application.Services
{
    public interface IPlayStationRoomGameService
    {
        Task<ApiResult<PlayStationRoomGameCMResponc>> CreatePlayStationRoomGameAsync(PlayStationRoomGameCM model);
        Task<ApiResult<PlayStationRoomGameRM>> GetByIdPlayStationRoomGameAsync(Guid id);
        Task<ApiResult<IEnumerable<PlayStationRoomGameRM>>> GetAllPlayStationRoomGameAsync();
        Task<ApiResult<PlayStationRoomGameUMResponce>> UpdatePlayStationRoomGameAsync(PlayStationRoomGameUM model);
        Task<ApiResult<bool>> DeletePlayStationRoomGameAsync(Guid id);
    }
}
