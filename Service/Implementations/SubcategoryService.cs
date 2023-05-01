using AutoMapper;
using webApi.Data.Dtos;
using webApi.Models;
using webApi.Repositories.Implementations;
using webApi.Repository.Interface;

namespace webApi.Service.Implementations
{
    public class SubcategoryService : ISubcategoryService
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;

        public SubcategoryService(ISubcategoryRepository subcategoryRepository, IMapper mapper)
        {
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<SubcategoryDto>> GetAllSubcategoriesAsync()
        {
            var subcategories = await _subcategoryRepository.GetAllAsync();
            return _mapper.Map<List<SubcategoryDto>>(subcategories);
        }

        public async Task<SubcategoryDto> GetSubcategoryByIdAsync(int id)
        {
            var subcategory = await _subcategoryRepository.GetByIdAsync(id);
            return _mapper.Map<SubcategoryDto>(subcategory);
        }

        public async Task<CreateSubcategoryDto> CreateSubcategoryAsync(CreateSubcategoryDto createSubcategoryDto)
        {
            var subcategory = _mapper.Map<Subcategory>(createSubcategoryDto);
            await _subcategoryRepository.CreateAsync(subcategory);
            return _mapper.Map<CreateSubcategoryDto>(subcategory);
        }

        public async Task<UpdateSubcategoryDto> UpdateSubcategoryAsync(int id, UpdateSubcategoryDto subcategoryDTO)
        {
            var subcategory = await _subcategoryRepository.GetByIdAsync(id);
            if (subcategory == null)
            {
                return null;
            }
            _mapper.Map(subcategoryDTO, subcategory);
            await _subcategoryRepository.UpdateAsync(subcategory);
            return _mapper.Map<UpdateSubcategoryDto>(subcategory);
        }

        public async Task DeleteSubcategoryAsync(int id)
        {
            var subcategory = await _subcategoryRepository.GetByIdAsync(id);
            if (subcategory == null)
            {
                throw new Exception("Subcategory not found.");
            }

            await _subcategoryRepository.DeleteAsync(subcategory);
        }
    }
}
