using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApi.Data;
using webApi.Data.Dtos;
using webApi.Models;

namespace webApi.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;

        public CategoryController(ContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            var category = _context.Categories.ToList();
            var categoryDto = _mapper.Map<List<CategoryDto>>(category);
            return Ok(categoryDto);
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategoryById(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return _mapper.Map<CategoryDto>(category);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            Category category = _mapper.Map<Category>(createCategoryDto);

            if (_context.Categories.Any(p => p.Name == createCategoryDto.Name))
            {
                return Conflict("Category already exists.");
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public ActionResult<CategoryDto> UpdateCategory(int id, [FromBody] UpdateCategoryDto categoryDto)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _mapper.Map(categoryDto, category);

            _context.Categories.Update(category);
            _context.SaveChanges();

            return _mapper.Map<CategoryDto>(category);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

