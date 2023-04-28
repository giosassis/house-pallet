using webApi.Data.Dtos;
using AutoMapper;
using webApi.Models;

namespace webApi.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<UpdateCustomerDto, Customer>();
        CreateMap<Customer, CustomerDto>();
        CreateMap<Customer, UpdateCustomerDto>();
    }
}
