using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;
using webApi.Repository.Interface;
using WebApi.Models;

namespace webApi.Repository.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ContextDb _dbContext;
        public CustomerRepository(ContextDb dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> UpdateCustomerAsync(int id, Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customer.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return false;
            }

            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        private bool CustomerExists(int id)
        {
            return _dbContext.Customers.Any(p => p.Id == id);
        }

        public async Task<bool> CustomerExistsWithCpfAsync(string cpf)
        {
            return await _dbContext.Customers.AnyAsync(c => c.Cpf == cpf);
        }
    }
}