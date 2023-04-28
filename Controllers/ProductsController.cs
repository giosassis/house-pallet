using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApi.Data;
using webApi.Data.Dtos;
using webApi.Models;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;
        public ProductsController(ContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            var productsDto = _mapper.Map<List<ProductsDto>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public ActionResult<Products> GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound("Product doesn't exists on database");
            var productDto = _mapper.Map<ProductsDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            Products product = _mapper.Map<Products>(createProductDto);

            if (_context.Products.Any(p => p.Name == createProductDto.Name))
            {
                return Conflict("Product already exists.");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound("Product doesn't exists on database");
            _mapper.Map(updateProductDto, product);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound("Product doesn't exists on database");

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}