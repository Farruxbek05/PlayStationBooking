using AutoMapper;
using Playstation.Application.Models.Review;
using Playstation.Domain.Entity;

namespace Playstation.Application.MappingProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewCM, Review>();
            CreateMap<Review, ReviewRM>();
            CreateMap<ReviewUM, Review>();
        }
    }
}
