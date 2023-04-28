using webApi.Data.Dtos;
using AutoMapper;
using webApi.Models;

namespace webApi.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderDto, Order>();
            CreateMap<UpdateOrderDto, Order>();
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => $"{src.CustomerId}"))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice.ToString("C2")));
            CreateMap<Order, UpdateOrderDto>();
        }
    }
}


namespace webApi.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<CreateOrderItemDto, OrderItem>();
            CreateMap<UpdateOrderItemDto, OrderItem>();
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.ToString("C2")));
            CreateMap<OrderItem, UpdateOrderItemDto>();
        }
    }
}
