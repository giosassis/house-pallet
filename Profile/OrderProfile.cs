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
            CreateMap<Order, OrderDto>();
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
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItem, UpdateOrderItemDto>();
        }
    }
}
