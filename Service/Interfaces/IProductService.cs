using webApi.Data.Dtos;
using webApi.Models;

namespace webApi.Service.Interface
{
    public interface IProductService
    {
        Task<List<ProductsDto>> GetAllProductsAsync();
        Task<ProductsDto> GetProductByIdAsync(int id);
        Task<CreateProductDto> AddProductAsync(CreateProductDto createProductDto);
        Task<bool> UpdateProductAsync(int id, UpdateProductDto productDto);
        Task<bool> DeleteProductAsync(int id);
        Task UpdateProductStockAsync(Order order);
    }
}
