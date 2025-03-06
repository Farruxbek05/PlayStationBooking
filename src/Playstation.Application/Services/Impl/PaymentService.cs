using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Playstation.Application.Models;
using Playstation.Application.Models.Payment;
using Playstation.Domain.Entity;
using Playstation.Infrastructure.Persistence;

namespace Playstation.Application.Services.Impl
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly PlayStationDbContext _dbContext;

        public PaymentService(IMapper mapper, PlayStationDbContext context)
        {
            _mapper = mapper;
            _dbContext = context;
        }

        public async Task<ApiResult<PaymentCMResponce>> CreatePaymentAsync(PaymentCM model)
        {
            var payment = _mapper.Map<Payment>(model);
            payment.CreatedOn = DateTime.UtcNow;

            _dbContext.Payments.Add(payment);
            await _dbContext.SaveChangesAsync();

            return ApiResult<PaymentCMResponce>.Success(new PaymentCMResponce
            {
                Id = payment.Id
            });
        }

        public async Task<ApiResult<bool>> DeletePaymentAsync(Guid id)
        {
            var payment = _dbContext.Payments.FirstOrDefault(t => t.Id == id);
            if (payment == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "Payment not found" });
            }

            _dbContext.Payments.Remove(payment);

            await _dbContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<IEnumerable<PaymentRM>>> GetAllPaymentAsync()
        {
            var payment = await _dbContext.Payments
                                            .AsNoTracking()
                                            .ProjectTo<PaymentRM>(_mapper.ConfigurationProvider)
                                            .ToListAsync();


            return ApiResult<IEnumerable<PaymentRM>>.Success(payment);
        }

        public async Task<ApiResult<PaymentRM>> GetByIdPaymentAsync(Guid id)
        {
            var payment = await _dbContext.Payments
              .AsNoTracking()
              .ProjectTo<PaymentRM>(_mapper.ConfigurationProvider)
              .FirstOrDefaultAsync(c => c.Id == id);

            if (payment == null)
            {
                return ApiResult<PaymentRM>.Failure(new List<string> { "Payment not found" });
            }

            return ApiResult<PaymentRM>.Success(payment);
        }

        public async Task<ApiResult<PaymentUMResponce>> UpdatePaymentAsync(PaymentUM model)
        {
            var payment = await _dbContext.Payments.FirstOrDefaultAsync(s => s.Id == model.Id);

            if (payment == null)
            {
                return ApiResult<PaymentUMResponce>.Failure(new List<string> { "Payment not found" });
            }

            _mapper.Map(model, payment);
            payment.UpdatedOn = DateTime.Now;
            _dbContext.Payments.Update(payment);
            await _dbContext.SaveChangesAsync();

            return ApiResult<PaymentUMResponce>.Success(new PaymentUMResponce
            {
                Id = payment.Id,
            });
        }
    }
}
