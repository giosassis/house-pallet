using webApi.Data.Dtos;

namespace webApi.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<CreateCategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto);
        Task<UpdateCategoryDto> UpdateCategoryAsync(int id, UpdateCategoryDto categoryDto);
        Task DeleteCategoryAsync(int id);
    }
}
