using AutoMapper;
using Playstation.Application.Models.Game;
using Playstation.Domain.Entity;

namespace Playstation.Application.MappingProfiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameCM, Game>();
            CreateMap<Game, GameRM>();
            CreateMap<GameUM, Game>();
        }
    }
}
