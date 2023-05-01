using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Data.Dtos;
using webApi.Models;

namespace webApi.Repository.Interface
{
    public interface IOrderItemService
    {
        Task<List<OrderItemDto>> GetAllOrderItemsAsync();
        Task<OrderItemDto> GetOrderItemByIdAsync(int id);
        Task<CreateOrderItemDto> CreateOrderItemAsync(CreateOrderItemDto createOrderItemDto);
        Task<UpdateOrderItemDto> UpdateOrderItemAsync(int id, UpdateOrderItemDto orderItemDto);
        Task<bool> DeleteOrderItemAsync(int id);
    }
}
