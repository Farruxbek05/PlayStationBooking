using AutoMapper;
using Playstation.Application.Models.Console;
using Playstation.Domain.Entity;

namespace Playstation.Application.MappingProfiles
{
    public class PlayStationRoomProfile : Profile
    {
        public PlayStationRoomProfile()
        {
            CreateMap<PlayStationRoomCM, PlayStationRoom>();
            CreateMap<PlayStationRoom, PlayStationRoomRM>();
            CreateMap<PlayStationRoomUM, PlayStationRoom>();

        }
    }
}
