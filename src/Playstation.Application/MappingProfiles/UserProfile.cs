using AutoMapper;
using Playstation.Application.Models.User;
using Playstation.Domain.Entity;

namespace Playstation.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserModel, User>()
           .ReverseMap();
        }
    }
}
