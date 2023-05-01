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
            CreateMap<CreateOrderDto, OrderDto>();
            CreateMap<UpdateOrderDto, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<Order, UpdateOrderDto>();
            CreateMap<Order, CreateOrderDto>();
            CreateMap<OrderDto, Order>();
        }
    }
}


namespace webApi.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId)); ;
            CreateMap<OrderItem, UpdateOrderItemDto>();
            CreateMap<OrderItem, CreateOrderItemDto>();
            CreateMap<OrderItemDto, OrderItem>();
            CreateMap<CreateOrderItemDto, OrderItem>();
            CreateMap<UpdateOrderItemDto, OrderItem>();
        }
    }
}
