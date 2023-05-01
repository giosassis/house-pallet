using webApi.Data.Dtos;
using AutoMapper;
using webApi.Models;
using WebApi.Models;

namespace webApi.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<CreateCustomerDto, CustomerDto>();
        CreateMap<Customer, CreateCustomerDto>();
        CreateMap<Customer, UpdateCustomerDto>();
        CreateMap<UpdateCustomerDto, Customer>();
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();
    }
}
