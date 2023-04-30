using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;
using webApi.Repositories.Interfaces;
using webApi.Repository.Interface;

namespace webApi.Repositories.Implementations
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ContextDb _context;

        public OrderItemRepository(ContextDb context)
        {
            _context = context;
        }

        public async Task<List<OrderItem>> GetOrderItemsAsync()
        {
            return await _context.Set<OrderItem>().ToListAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            return await _context.Set<OrderItem>().FindAsync(id);
        }

        public async Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItem)
                .ThenInclude(oi => oi.Products)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                // retorna uma lista vazia ou lança uma exceção, dependendo do que for mais adequado para o seu cenário
                return new List<OrderItem>();
            }

            return order.OrderItemId;
        }

        public async Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem)
        {
            _context.Set<OrderItem>().Add(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        public async Task<OrderItem> UpdateOrderItemAsync(int id, OrderItem orderItem)
        {
            var existingOrderItem = await _context.Set<OrderItem>().FindAsync(id);
            if (existingOrderItem != null)
            {
                existingOrderItem.ProductId = orderItem.ProductId;
                existingOrderItem.Quantity = orderItem.Quantity;
                existingOrderItem.Price = orderItem.Price;

                await _context.SaveChangesAsync();
            }
            return existingOrderItem;
        }

        public async Task<bool> DeleteOrderItemAsync(int id)
        {
            var existingOrderItem = await _context.Set<OrderItem>().FindAsync(id);
            if (existingOrderItem != null)
            {
                _context.Set<OrderItem>().Remove(existingOrderItem);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
