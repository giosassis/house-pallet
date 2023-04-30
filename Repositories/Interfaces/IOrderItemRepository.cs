using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Repository.Interface
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAllOrderItemsAsync();
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem);
        Task<OrderItem> UpdateOrderItemAsync(int id, OrderItem orderItem);
        Task<bool> DeleteOrderItemAsync(int id);
    }
}
