using webApi.Data.Dtos;
using AutoMapper;
using webApi.Models;

namespace webApi.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<CreateCategoryDto, CategoryDto>();
        CreateMap<UpdateCategoryDto, Category>();
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
        CreateMap<Category, UpdateCategoryDto>();
    }
}