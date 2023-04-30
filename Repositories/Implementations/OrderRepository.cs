using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Data.Dtos;
using webApi.Models;
using webApi.Repositories.Interfaces;
using webApi.Repository.Interface;

namespace webApi.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ContextDb _context;

        public OrderRepository(ContextDb context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Set<Order>()
             .Include(order => order.Customer)
             .Include(order => order.DeliveryAddress)
             .Include(order => order.PaymentMethod)
             .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Set<Order>()
             .Include(order => order.Customer)
             .Include(order => order.DeliveryAddress)
             .Include(order => order.PaymentMethod)
             .FirstOrDefaultAsync(order => order.Id == id);
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Set<Order>().Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrderAsync(int id, Order order)
        {
            _context.Set<Order>().Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await GetOrderByIdAsync(id);
            if (order != null)
            {
                _context.Set<Order>().Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
