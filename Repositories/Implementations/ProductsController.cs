using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Data.Dtos;
using webApi.Models;
using webApi.Service.Interface;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var productsDto = await _productService.GetAllProductsAsync();
            var products = _mapper.Map<List<ProductsDto>>(productsDto);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<CreateProductDto>> CreateProduct(CreateProductDto createProductDto)
        {
            var createdProductDto = await _productService.AddProductAsync(createProductDto);
            var createdProduct = _mapper.Map<Products>(createdProductDto);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto product)
        {
            if (id != product.Id) return BadRequest();
            await _productService.UpdateProductAsync(id, product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}