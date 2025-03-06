using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Playstation.Application.Models;
using Playstation.Application.Models.BookingSnack;
using Playstation.Domain.Entity;
using Playstation.Infrastructure.Persistence;

namespace Playstation.Application.Services.Impl
{
    public class BookingSnackService : IBookingSnackService
    {
        private readonly IMapper _mapper;
        private readonly PlayStationDbContext _dbContext;

        public BookingSnackService(IMapper mapper, PlayStationDbContext context)
        {
            _mapper = mapper;
            _dbContext = context;
        }

        public async Task<ApiResult<CreateBookingSnackResponceModel>> CreateBookingSnackAsync(BookingSnackCM model)
        {
            var bookingsnack = _mapper.Map<BookingSnack>(model);
            bookingsnack.CreatedOn = DateTime.UtcNow;

            _dbContext.BookingSnacks.Add(bookingsnack);
            await _dbContext.SaveChangesAsync();

            return ApiResult<CreateBookingSnackResponceModel>.Success(new CreateBookingSnackResponceModel
            {
                Id = bookingsnack.Id
            });
        }

        public async Task<ApiResult<bool>> DeleteBookingSnackAsync(Guid id)
        {

            var bookingsnack = _dbContext.BookingSnacks.FirstOrDefault(t => t.Id == id);
            if (bookingsnack == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "BookingSnack not found" });
            }

            _dbContext.BookingSnacks.Remove(bookingsnack);

            await _dbContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<IEnumerable<BookingSnackRM>>> GetAllBookingSnackAsync()
        {
            var bookingsnack = await _dbContext.BookingSnacks
                                             .AsNoTracking()
                                             .ProjectTo<BookingSnackRM>(_mapper.ConfigurationProvider)
                                             .ToListAsync();


            return ApiResult<IEnumerable<BookingSnackRM>>.Success(bookingsnack);
        }

        public async Task<ApiResult<BookingSnackRM>> GetByIdBookingSnackAsync(Guid id)
        {
            var bookingsnack = await _dbContext.BookingSnacks
             .AsNoTracking()
             .ProjectTo<BookingSnackRM>(_mapper.ConfigurationProvider)
             .FirstOrDefaultAsync(c => c.Id == id);

            if (bookingsnack == null)
            {
                return ApiResult<BookingSnackRM>.Failure(new List<string> { "BookingSnack not found" });
            }

            return ApiResult<BookingSnackRM>.Success(bookingsnack);
        }

        public async Task<ApiResult<UpdateBookingSnackResponceModel>> UpdateBookingSnackAsync(BookingSnackUM model)
        {
            var bookingsnack = await _dbContext.BookingSnacks.FirstOrDefaultAsync(s => s.Id == model.Id);

            if (bookingsnack == null)
            {
                return ApiResult<UpdateBookingSnackResponceModel>.Failure(new List<string> { "Booking not found" });
            }

            _mapper.Map(model, bookingsnack);
            bookingsnack.UpdatedOn = DateTime.Now;
            _dbContext.BookingSnacks.Update(bookingsnack);
            await _dbContext.SaveChangesAsync();

            return ApiResult<UpdateBookingSnackResponceModel>.Success(new UpdateBookingSnackResponceModel
            {
                Id = bookingsnack.Id,
            });
        }
    }
}
