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

    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;

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
    public async Task<ActionResult<CreateCategoryDto>> CreateCategoryAsync(CreateCategoryDto categoryDto)
    {
        var createdCategory = await _categoryService.CreateCategoryAsync(categoryDto);
        return CreatedAtAction(nameof(GetCategoryByIdAsync), new { id = createdCategory.Id }, createdCategory);
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
