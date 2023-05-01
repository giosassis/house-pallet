using AutoMapper;
using webApi.Data.Dtos;
using webApi.Models;

namespace webApi.Profiles
{
    public class SubcategoryProfile : Profile
    {
        public SubcategoryProfile()
        {
            CreateMap<CreateSubcategoryDto, SubcategoryDto>();
            CreateMap<CreateSubcategoryDto, Subcategory>();
            CreateMap<Subcategory, CreateSubcategoryDto>();
            CreateMap<UpdateSubcategoryDto, Subcategory>();
            CreateMap<Subcategory, SubcategoryDto>();
            CreateMap<SubcategoryDto, Subcategory>();
            CreateMap<Subcategory, UpdateSubcategoryDto>();
        }
    }
}
