using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Repository.Interface
{
    public interface ISubcategoryRepository
    {
        Task<List<Subcategory>> GetAllSubcategoriesAsync();
        Task<Subcategory> GetSubcategoryByIdAsync(int subcategoryId);
        Task<List<Subcategory>> GetSubcategoriesByCategoryIdAsync(int categoryId);
        Task AddSubcategoryAsync(Subcategory subcategory);
        Task<bool> UpdateSubcategoryAsync(Subcategory subcategory);
        Task<bool> DeleteSubcategoryAsync(int subcategoryId);
    }
}
