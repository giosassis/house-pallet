using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Repository.Interface
{
    public interface IProductRepository
    {
        Task<List<Products>> GetAllProductsAsync();
        Task<Products> GetProductByIdAsync(int id);
        Task<Products> AddProductAsync(Products product);
        Task<bool> UpdateProductAsync(Products product);
        Task<bool> DeleteProductAsync(int id);
    }
}
