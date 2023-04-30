using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(int id);
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(int id, Order order);
        Task DeleteOrderAsync(int id);
    }
}
