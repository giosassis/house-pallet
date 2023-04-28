using webApi.Data.Dtos;
using AutoMapper;
using webApi.Models;

    public class PaymentMethodTypeProfile : Profile
    {
        public PaymentMethodTypeProfile() {
            CreateMap<PaymentMethodType, PaymentMethodTypeDto>();
        }
    }
