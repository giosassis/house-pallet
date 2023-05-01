using AutoMapper;
using webApi.Data.Dtos;
using webApi.Models;
using webApi.Repository.Interface;
using webApi.Service.Implementation;

namespace webApi.Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly ProductService _productService;

        public OrderService(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
              }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<CreateOrderDto> CreateOrderAsync(CreateOrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            order = await _orderRepository.CreateOrderAsync(order);
            await _productService.UpdateProductStockAsync(order);
            return _mapper.Map<CreateOrderDto>(order);
        }

        public async Task<UpdateOrderDto> UpdateOrderAsync(int id, UpdateOrderDto orderDto)
        {
            var existingOrder = await _orderRepository.GetOrderByIdAsync(id);
            if (existingOrder == null)
            {
                throw new ArgumentException("Order not found");
            }
            var order = _mapper.Map(orderDto, existingOrder);
            order = await _orderRepository.UpdateOrderAsync(id, order);
            return _mapper.Map<UpdateOrderDto>(order);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                return false;
            }
            await _orderRepository.DeleteOrderAsync(id);
            return true;
        }
    }
}
