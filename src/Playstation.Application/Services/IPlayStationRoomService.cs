using Playstation.Application.Models;
using Playstation.Application.Models.Console;

namespace Playstation.Application.Services
{
    public interface IPlayStationRoomService
    {
        Task<ApiResult<PlayStationRoomCMResponce>> CreatePlayStationRoomAsync(PlayStationRoomCM model);
        Task<ApiResult<PlayStationRoomRM>> GetByIdPlayStationRoomAsync(Guid id);
        Task<ApiResult<IEnumerable<PlayStationRoomRM>>> GetAllPlayStationRoomAsync();
        Task<ApiResult<PlayStationRoomUMResponce>> UpdatePlayStationRoomAsync(PlayStationRoomUM model);
        Task<ApiResult<bool>> DeletePlayStationRoomAsync(Guid id);
    }
}
