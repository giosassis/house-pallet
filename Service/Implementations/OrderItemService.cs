using AutoMapper;
using webApi.Data.Dtos;
using webApi.Models;
using webApi.Repository.Interface;

namespace webApi.Service.Implementations
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderItemDto>> GetAllOrderItemsAsync()
        {
            var orderItems = await _orderItemRepository.GetAllOrderItemsAsync();
            return _mapper.Map<List<OrderItemDto>>(orderItems);
        }

        public async Task<OrderItemDto> GetOrderItemByIdAsync(int id)
        {
            var orderItem = await _orderItemRepository.GetOrderItemByIdAsync(id);
            return _mapper.Map<OrderItemDto>(orderItem);
        }

        public async Task<CreateOrderItemDto> CreateOrderItemAsync(CreateOrderItemDto createOrderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(createOrderItemDto);
            orderItem = await _orderItemRepository.CreateOrderItemAsync(orderItem);
            return _mapper.Map<CreateOrderItemDto>(orderItem);
        }

        public async Task<UpdateOrderItemDto> UpdateOrderItemAsync(int id, UpdateOrderItemDto createOrderItemDto)
        {
            var existingOrderItem = await _orderItemRepository.GetOrderItemByIdAsync(id);
            if (existingOrderItem == null)
            {
                return null;
            }

            var orderItem = _mapper.Map(createOrderItemDto, existingOrderItem);
            orderItem = await _orderItemRepository.UpdateOrderItemAsync(id, orderItem);
            return _mapper.Map<UpdateOrderItemDto>(orderItem);
        }

        public async Task<bool> DeleteOrderItemAsync(int id)
        {
            return await _orderItemRepository.DeleteOrderItemAsync(id);
        }
    }

}
