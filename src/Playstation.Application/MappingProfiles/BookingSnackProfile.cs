using AutoMapper;
using Playstation.Application.Models.BookingSnack;
using Playstation.Domain.Entity;

namespace Playstation.Application.MappingProfiles
{
    public class BookingSnackProfile : Profile
    {
        public BookingSnackProfile()
        {
            CreateMap<BookingSnackCM, BookingSnack>();
            CreateMap<BookingSnack, BookingSnackRM>();
            CreateMap<BookingSnackUM, BookingSnack>();
        }
    }
}
