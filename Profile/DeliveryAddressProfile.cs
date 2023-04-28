using AutoMapper;
using webApi.Data.Dtos;
using webApi.Models;

namespace webApi.Profiles
{
    public class DeliveryAddressProfile : Profile
    {
        public DeliveryAddressProfile()
        {
            CreateMap<DeliveryAddressCreateDto, DeliveryAddress>();
            CreateMap<DeliveryAddressUpdateDto, DeliveryAddress>();
            CreateMap<DeliveryAddress, DeliveryAddressReadDto>();
            CreateMap<DeliveryAddress, DeliveryAddressUpdateDto>();
        }
    }
}