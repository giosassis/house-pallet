using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApi.Data.Dtos;
using webApi.Models;
using webApi.Service.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;

    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAllCategoriesAsync()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        var createdCategory = await _categoryService.CreateCategoryAsync(createCategoryDto);
        var categoryDto = _mapper.Map<CategoryDto>(createdCategory);
        return CreatedAtAction(nameof(GetCategoryByIdAsync), new { id = categoryDto.Id }, categoryDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateCategoryDto>> UpdateCategoryAsync(int id, UpdateCategoryDto categoryDto)
    {
        try
        {
            var updatedCategory = await _categoryService.UpdateCategoryAsync(id, categoryDto);
            return Ok(updatedCategory);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCategoryAsync(int id)
    {
        try
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}
