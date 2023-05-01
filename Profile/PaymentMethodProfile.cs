using webApi.Data.Dtos;
using AutoMapper;
using webApi.Models;

namespace webApi.Profiles;

public class PaymentMethodProfile : Profile
{
    public PaymentMethodProfile()
    {
        CreateMap<CreatePaymentMethodDto, PaymentMethod>();
        CreateMap<CreatePaymentMethodDto, PaymentMethodDto>();
        CreateMap<PaymentMethod, CreatePaymentMethodDto>();
        CreateMap<UpdatePaymentMethodDto, PaymentMethod>();
        CreateMap<PaymentMethod, PaymentMethodDto>();
        CreateMap<PaymentMethodDto, PaymentMethod>();
        CreateMap<PaymentMethod, UpdatePaymentMethodDto>();
    }
}
