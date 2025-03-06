using Playstation.Application.Models;
using Playstation.Application.Models.Location;

namespace Playstation.Application.Services;

public interface ILocationService
{
    Task<ApiResult<LocationCMResponce>> CreateLocationAsync(LocationCM model);
    Task<ApiResult<LocationRM>> GetByIdLocationAsync(Guid id);
    Task<ApiResult<IEnumerable<LocationRM>>> GetAllLocationAsync();
    Task<ApiResult<LocationUMResponce>> UpdateLocationAsync(LocationUM model);
    Task<ApiResult<bool>> DeleteLocationAsync(Guid id);
}
