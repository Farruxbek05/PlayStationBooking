using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Playstation.Application.Models;
using Playstation.Application.Models.Booking;
using Playstation.Domain.Entity;
using Playstation.Infrastructure.Persistence;

namespace Playstation.Application.Services.Impl
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly PlayStationDbContext _dbContext;

        public BookingService(IMapper mapper, PlayStationDbContext context)
        {
            _mapper = mapper;
            _dbContext = context;
        }

        public async Task<ApiResult<CreateBookResponceModel>> CreateBookingAsync(BookingCM model)
        {
            var booking = _mapper.Map<Booking>(model);
            booking.CreatedOn = DateTime.UtcNow;

            _dbContext.Bookings.Add(booking);
            await _dbContext.SaveChangesAsync();

            return ApiResult<CreateBookResponceModel>.Success(new CreateBookResponceModel
            {
                Id = booking.Id
            });
        }

        public async Task<ApiResult<bool>> DeleteBookingAsync(Guid id)
        {
            var booking = _dbContext.Bookings.FirstOrDefault(t => t.Id == id);
            if (booking == null)
            {
                return ApiResult<bool>.Failure(new List<string> { "Booking not found" });
            }

            _dbContext.Bookings.Remove(booking);

            await _dbContext.SaveChangesAsync();

            return ApiResult<bool>.Success(true);
        }

        public async Task<ApiResult<IEnumerable<BookingRM>>> GetAllBookingAsync()
        {
            var booking = await _dbContext.Bookings
                                             .AsNoTracking()
                                             .ProjectTo<BookingRM>(_mapper.ConfigurationProvider)
                                             .ToListAsync();


            return ApiResult<IEnumerable<BookingRM>>.Success(booking);
        }

        public async Task<ApiResult<BookingRM>> GetByIdBookingAsync(Guid id)
        {
            var booking = await _dbContext.Bookings
             .AsNoTracking()
             .ProjectTo<BookingRM>(_mapper.ConfigurationProvider)
             .FirstOrDefaultAsync(c => c.Id == id);

            if (booking == null)
            {
                return ApiResult<BookingRM>.Failure(new List<string> { "Booking not found" });
            }

            return ApiResult<BookingRM>.Success(booking);
        }

        public async Task<ApiResult<UpdateBookResponceModel>> UpdateBookingAsync(BookingUM model)
        {
            var booking = await _dbContext.Bookings.FirstOrDefaultAsync(s => s.Id == model.Id);

            if (booking == null)
            {
                return ApiResult<UpdateBookResponceModel>.Failure(new List<string> { "Booking not found" });
            }

            _mapper.Map(model, booking);
            booking.UpdatedOn = DateTime.Now;
            _dbContext.Bookings.Update(booking);
            await _dbContext.SaveChangesAsync();

            return ApiResult<UpdateBookResponceModel>.Success(new UpdateBookResponceModel
            {
                Id = booking.Id,
            });
        }
    }
}
