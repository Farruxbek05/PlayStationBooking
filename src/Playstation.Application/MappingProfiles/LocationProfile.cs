using AutoMapper;
using Playstation.Application.Models.Location;
using Playstation.Domain.Entity;

namespace Playstation.Application.MappingProfiles;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        CreateMap<Location, LocationCM>();
        CreateMap<LocationRM, Location>();
        CreateMap<Location, LocationUM>();
    }
}
