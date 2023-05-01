using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApi.Data;
using webApi.Data.Dtos;
using webApi.Models;
using System.Collections.Generic;
using System.Linq;
using webApi.Repository.Interface;
using static webApi.Data.Dtos.UpdateSubcategoryDto;
using webApi.Repositories.Implementations;
using webApi.Service.Implementations;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoryController : ControllerBase
    {
        private readonly ISubcategoryService _subcategoryService;
        private readonly IMapper _mapper;

        public SubcategoryController(ISubcategoryService subcategoryService, IMapper mapper)
        {
            _subcategoryService = subcategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubcategoryDto>>> GetAllSubcategoriesAsync()
        {
            var subcategories = await _subcategoryService.GetAllSubcategoriesAsync();
            var subcategoryDtos = _mapper.Map<List<SubcategoryDto>>(subcategories);
            return Ok(subcategoryDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubcategoryDto>> GetSubcategoryByIdAsync(int id)
        {
            var subcategory = await _subcategoryService.GetSubcategoryByIdAsync(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            var subcategoryDto = _mapper.Map<SubcategoryDto>(subcategory);
            return Ok(subcategoryDto);
        }

        [HttpPost]
        public async Task<ActionResult<CreateSubcategoryDto>> CreateSubcategoryAsync(CreateSubcategoryDto subcategoryCreateDto)
        {
            var subcategory = _mapper.Map<CreateSubcategoryDto>(subcategoryCreateDto);
            await _subcategoryService.CreateSubcategoryAsync(subcategory);

            var subcategoryReadDto = _mapper.Map<SubcategoryDto>(subcategory);
            return CreatedAtRoute(nameof(GetSubcategoryByIdAsync), new { id = subcategoryReadDto.Id }, subcategoryReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateSubcategoryDto>> UpdateDeliveryAddressAsync(int id, UpdateSubcategoryDto updateSubcategoryDto)
        {
            await _subcategoryService.UpdateSubcategoryAsync(id, updateSubcategoryDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubcategoryAsync(int id)
        {
            var subcategory = await _subcategoryService.GetSubcategoryByIdAsync(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            await _subcategoryService.DeleteSubcategoryAsync(id);

            return NoContent();
        }
    }
}
