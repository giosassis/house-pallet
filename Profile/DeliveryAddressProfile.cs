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
            CreateMap<DeliveryAddress, DeliveryAddressCreateDto>();
            CreateMap<DeliveryAddressReadDto, DeliveryAddress>();
            CreateMap<DeliveryAddressUpdateDto, DeliveryAddress>();
            CreateMap<DeliveryAddress, DeliveryAddressReadDto>();
            CreateMap<DeliveryAddress, DeliveryAddressUpdateDto>();
            CreateMap<DeliveryAddressCreateDto, DeliveryAddressReadDto>();
        }
    }
}