using AutoMapper;
using webApi.Data.Dtos;
using webApi.Models;

namespace webApi.Profiles
{
    public class SubcategoryProfile : Profile
    {
        public SubcategoryProfile()
        {
            CreateMap<CreateSubcategoryDto, Subcategory>();
            CreateMap<UpdateSubcategoryDto, Subcategory>();
            CreateMap<Subcategory, SubcategoryDto>();
            CreateMap<Subcategory, UpdateSubcategoryDto>();
        }
    }
}
