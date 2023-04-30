using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;
using webApi.Repository.Interface;

namespace webApi.Repository.Implementation
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly ContextDb _dbContext;
        public SubcategoryRepository(ContextDb dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Subcategory>> GetAllAsync()
        {
            return await _dbContext.Subcategories.Include(s => s.Category).ToListAsync();
        }

        public async Task<Subcategory> GetByIdAsync(int id)
        {
            return await _dbContext.Subcategories.Include(s => s.Category).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<int> CreateAsync(Subcategory subcategory)
        {
            _dbContext.Subcategories.Add(subcategory);
            await _dbContext.SaveChangesAsync();
            return subcategory.Id;
        }

        public async Task UpdateAsync(Subcategory subcategory)
        {
            _dbContext.Subcategories.Update(subcategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Subcategory subcategory)
        {
            _dbContext.Subcategories.Remove(subcategory);
            await _dbContext.SaveChangesAsync();
        }
    }
}
