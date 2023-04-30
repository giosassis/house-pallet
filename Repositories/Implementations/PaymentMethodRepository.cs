using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;
using webApi.Repository.Interface;

namespace webApi.Repositories.Implementations
{
    public class PaymentMethodRepository : IPaymentMethodRepository 
    {
        private readonly ContextDb _context;

        public PaymentMethodRepository(ContextDb context)
        {
            _context = context;
        }

        public async Task<List<PaymentMethod>> GetAllAsync()
        {
            return await _context.PaymentMethods.ToListAsync();
        }

        public async Task<PaymentMethod> GetByIdAsync(int id)
        {
            return await _context.PaymentMethods.FindAsync(id);
        }

        public async Task AddAsync(PaymentMethod paymentMethod)
        {
            await _context.PaymentMethods.AddAsync(paymentMethod);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Update(paymentMethod);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Remove(paymentMethod);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethod != null)
            {
                _context.PaymentMethods.Remove(paymentMethod);
                await _context.SaveChangesAsync();
            }
        }
    }
    
}
