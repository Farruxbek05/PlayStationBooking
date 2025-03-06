using AutoMapper;
using Playstation.Application.Models.Payment;
using Playstation.Domain.Entity;

namespace Playstation.Application.MappingProfiles
{
    public class PaynetProfile : Profile
    {
        public PaynetProfile()
        {
            CreateMap<PaymentCM, Payment>();
            CreateMap<Payment, PaymentRM>();
            CreateMap<PaymentUM, Payment>();
        }
    }
}
