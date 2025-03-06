using AutoMapper;
using Playstation.Application.Models.Snack;
using Playstation.Domain.Entity;

namespace Playstation.Application.MappingProfiles
{
    public class SnackProfile : Profile
    {
        public SnackProfile()
        {
            CreateMap<SnackCM, Snack>();
            CreateMap<Snack, SnackRM>();
            CreateMap<SnackUM, Snack>();
        }
    }
}
