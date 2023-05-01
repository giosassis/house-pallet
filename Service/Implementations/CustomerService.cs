using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Data.Dtos;
using webApi.Models;
using webApi.Repositories.Interfaces;
using webApi.Repository.Interface;
using webApi.Service.Interfaces;
using webApi.Validators;
using WebApi.Models;

namespace webApi.Service.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            return _mapper.Map<List<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CreateCustomerDto> CreateCustomerAsync(CreateCustomerDto customerDto)
        {
            
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.CreateCustomerAsync(customer);
            return _mapper.Map<CreateCustomerDto>(customer);
        }

        public async Task<UpdateCustomerDto> UpdateCustomerAsync(int id, UpdateCustomerDto customerDto)
        {
            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(id);
            if (existingCustomer == null)
            {
                throw new ArgumentException("Customer not found");
            }

            var customer = _mapper.Map(customerDto, existingCustomer);
            await _customerRepository.UpdateCustomerAsync(id, customer);
            return _mapper.Map<UpdateCustomerDto>(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            {
                var customer = await _customerRepository.GetCustomerByIdAsync(id);
                if (customer == null)
                {
                    throw new ArgumentException("Customer not found");
                }

                await _customerRepository.DeleteCustomerAsync(id);
            }
        }
    }
}
