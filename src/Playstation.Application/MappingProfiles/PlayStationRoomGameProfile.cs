using AutoMapper;
using Playstation.Application.Models.PlayStationRoomGame;
using Playstation.Domain.Entity;

namespace Playstation.Application.MappingProfiles;

public class PlayStationRoomGameProfile : Profile
{
    public PlayStationRoomGameProfile()
    {
        CreateMap<PlayStationRoomGame, PlayStationRoomGameCM>();
        CreateMap<PlayStationRoomGameRM, PlayStationRoomGame>();
        CreateMap<PlayStationRoomGame, PlayStationRoomGameUM>();
    }
}
