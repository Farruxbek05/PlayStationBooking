using AutoMapper;
using Playstation.Application.Models.Booking;
using Playstation.Domain.Entity;

namespace Playstation.Application.MappingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingCM, Booking>();
            CreateMap<Booking, BookingRM>();
            CreateMap<BookingUM, Booking>();
        }
    }
}
