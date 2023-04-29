using AutoMapper;
using webApi.Data.Dtos;
using webApi.Models;
using webApi.Repositories.Interfaces;
using webApi.Service.Interfaces;

namespace webApi.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }
        public async Task<CreateCategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.AddCategoryAsync(category);

            return _mapper.Map<CreateCategoryDto>(category);
        }

        public async Task<UpdateCategoryDto> UpdateCategoryAsync(int id, UpdateCategoryDto categoryDto)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(id);
            var category = _mapper.Map(categoryDto, existingCategory);
            await _categoryRepository.UpdateCategoryAsync(category);

            return _mapper.Map<UpdateCategoryDto>(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);

            if (category == null)
            {
                throw new ArgumentException("Category not found");
            }

            await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}
