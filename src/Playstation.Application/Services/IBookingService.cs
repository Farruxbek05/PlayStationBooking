using Playstation.Application.Models;
using Playstation.Application.Models.Booking;

namespace Playstation.Application.Services
{
    public interface IBookingService
    {
        Task<ApiResult<CreateBookResponceModel>> CreateBookingAsync(BookingCM model);
        Task<ApiResult<BookingRM>> GetByIdBookingAsync(Guid id);
        Task<ApiResult<IEnumerable<BookingRM>>> GetAllBookingAsync();
        Task<ApiResult<UpdateBookResponceModel>> UpdateBookingAsync(BookingUM model);
        Task<ApiResult<bool>> DeleteBookingAsync(Guid id);
    }
}
