using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Repository.Interface
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        Task<List<OrderItem>> GetOrderItemsAsync();
        Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int id);
        Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem);
        Task<OrderItem> UpdateOrderItemAsync(int id, OrderItem orderItem);
        Task<bool> DeleteOrderItemAsync(int id);
    }
}
