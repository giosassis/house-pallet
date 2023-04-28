using AutoMapper;
using webApi.Data.Dtos;
using webApi.Models;

public class ProductsProfile : Profile
{
    public ProductsProfile()
    {
        CreateMap<CreateProductDto, Products>();
        CreateMap<UpdateProductDto, Products>();
        CreateMap<Products, ProductsDto>();
        CreateMap<Products, UpdateProductDto>();
    }
}