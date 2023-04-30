using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApi.Data;
using webApi.Data.Dtos;
using webApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoryController : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;

        public SubcategoryController(ContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSubcategory()
        {
            var subcategory = _context.Subcategories.ToList();
            var subcategoryDto = _mapper.Map<List<SubcategoryDto>>(subcategory);
            return Ok(subcategoryDto);
        }

        [HttpGet("{id}")]
        public ActionResult<SubcategoryDto> GetSubcategoryById(int id)
        {
            var subcategory = _context.Subcategories.Find(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            return _mapper.Map<SubcategoryDto>(subcategory);
        }

        [HttpPost]
        public IActionResult CreateSubcategory([FromBody] CreateSubcategoryDto createSubcategoryDto)
        {
            Subcategory subcategory = _mapper.Map<Subcategory>(createSubcategoryDto);

            _context.Subcategories.Add(subcategory);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSubcategoryById), new { id = subcategory.Id }, subcategory);
        }

        [HttpPut("{id}")]
        public ActionResult<SubcategoryDto> UpdateSubcategory(int id, [FromBody] UpdateSubcategoryDto updateSubcategoryDto)
        {
            var subcategory = _context.Subcategories.Find(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            _mapper.Map(updateSubcategoryDto, subcategory);

            _context.Subcategories.Update(subcategory);
            _context.SaveChanges();

            return _mapper.Map<SubcategoryDto>(subcategory);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubcategory(int id)
        {
            var subcategory = _context.Subcategories.Find(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            _context.Subcategories.Remove(subcategory);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
