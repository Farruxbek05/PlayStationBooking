using Playstation.Application.Models;
using Playstation.Application.Models.Payment;

namespace Playstation.Application.Services
{
    public interface IPaymentService
    {
        Task<ApiResult<PaymentCMResponce>> CreatePaymentAsync(PaymentCM model);
        Task<ApiResult<PaymentRM>> GetByIdPaymentAsync(Guid id);
        Task<ApiResult<IEnumerable<PaymentRM>>> GetAllPaymentAsync();
        Task<ApiResult<PaymentUMResponce>> UpdatePaymentAsync(PaymentUM model);
        Task<ApiResult<bool>> DeletePaymentAsync(Guid id);
    }
}
