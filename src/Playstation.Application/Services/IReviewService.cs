using Playstation.Application.Models;
using Playstation.Application.Models.Review;

namespace Playstation.Application.Services
{
    public interface IReviewService
    {
        Task<ApiResult<ReviewCMResponce>> CreateReviewAsync(ReviewCM model);
        Task<ApiResult<ReviewRM>> GetByIdReviewAsync(Guid id);
        Task<ApiResult<IEnumerable<ReviewRM>>> GetAllReviewAsync();
        Task<ApiResult<ReviewUMResponce>> UpdateReviewAsync(ReviewUM model);
        Task<ApiResult<bool>> DeleteReviewAsync(Guid id);
    }
}
