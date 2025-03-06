using Playstation.Application.Models;
using Playstation.Application.Models.BookingSnack;

namespace Playstation.Application.Services
{
    public interface IBookingSnackService
    {
        Task<ApiResult<CreateBookingSnackResponceModel>> CreateBookingSnackAsync(BookingSnackCM model);
        Task<ApiResult<BookingSnackRM>> GetByIdBookingSnackAsync(Guid id);
        Task<ApiResult<IEnumerable<BookingSnackRM>>> GetAllBookingSnackAsync();
        Task<ApiResult<UpdateBookingSnackResponceModel>> UpdateBookingSnackAsync(BookingSnackUM model);
        Task<ApiResult<bool>> DeleteBookingSnackAsync(Guid id);
    }
}
