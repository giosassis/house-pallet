using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Repository.Interface
{
    public interface ISubcategoryRepository
    {
        Task<List<Subcategory>> GetAllAsync();
        Task<Subcategory> GetByIdAsync(int id);
        Task<int> CreateAsync(Subcategory subcategory);
        Task UpdateAsync(Subcategory subcategory);
        Task DeleteAsync(Subcategory subcategory);
    }
}
