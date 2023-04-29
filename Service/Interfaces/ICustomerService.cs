using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Data.Dtos;
using webApi.Models;

namespace webApi.Repository.Interface
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(int id);
        Task<CreateCustomerDto> CreateCustomerAsync(CreateCustomerDto customerDto);
        Task<UpdateCustomerDto> UpdateCustomerAsync(int id, UpdateCustomerDto customerDto);
        Task DeleteCustomerAsync(int id);
    }
}
