using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Repository.Interface
{
    public interface IOrderRepository
    {
       Task<Order> GetOrderByIdAsync(int id);
        Task<List<Order>> GetAllOrdersAsync();
        Task<List<Order>> GetOrdersByCustomerIdAsync(int customerId);
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);
    }
}
