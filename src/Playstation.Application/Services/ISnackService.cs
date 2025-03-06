using Playstation.Application.Models;
using Playstation.Application.Models.Snack;

namespace Playstation.Application.Services
{
    public interface ISnackService
    {
        Task<ApiResult<SnackCMResponce>> CreateSnackAsync(SnackCM model);
        Task<ApiResult<SnackRM>> GetByIdSnackAsync(Guid id);
        Task<ApiResult<IEnumerable<SnackRM>>> GetAllSnackAsync();
        Task<ApiResult<SnackUMResponce>> UpdateSnackAsync(SnackUM model);
        Task<ApiResult<bool>> DeleteSnackAsync(Guid id);
    }
}
