using AutoMapper;
using webApi.Data.Dtos;
using webApi.Models;
using webApi.Repository.Interface;
using webApi.Service.Interface;

namespace webApi.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductsDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<List<ProductsDto>>(products);
        }

        public async Task<ProductsDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return _mapper.Map<ProductsDto>(product);
        }

        public async Task<CreateProductDto> AddProductAsync(CreateProductDto productDto)
        {
            var product = _mapper.Map<Products>(productDto);
            var createdProduct = await _productRepository.AddProductAsync(product);
            return _mapper.Map<CreateProductDto>(createdProduct);
        }

        public async Task<bool> UpdateProductAsync(int id, UpdateProductDto productDto)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return false;
            }

            _mapper.Map(productDto, product);

            return await _productRepository.UpdateProductAsync(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }
    }
}
