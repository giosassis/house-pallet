using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;
using webApi.Repository.Interface;

namespace webApi.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ContextDb _dbContext; 
        public ProductRepository(ContextDb dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Products>> GetAllProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Products> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<Products> AddProductAsync(Products product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProductAsync(Products product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
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

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        private bool ProductExists(int id)
        {
            return _dbContext.Products.Any(p => p.Id == id);
        }
    }
}