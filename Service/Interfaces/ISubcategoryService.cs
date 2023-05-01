using webApi.Data.Dtos;


namespace webApi.Repository.Interface
{
    public interface ISubcategoryService
    {
        Task<List<SubcategoryDto>> GetAllSubcategoriesAsync();
        Task<SubcategoryDto> GetSubcategoryByIdAsync(int id);
        Task<CreateSubcategoryDto> CreateSubcategoryAsync(CreateSubcategoryDto createSubcategoryDto);
        Task<UpdateSubcategoryDto> UpdateSubcategoryAsync(int id, UpdateSubcategoryDto subcategory);
        Task DeleteSubcategoryAsync(int id);
    }
}
