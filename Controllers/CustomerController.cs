using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Data.Dtos;
using webApi.Models;
using webApi.Repository.Interface;
using webApi.Service.Implementations;
using webApi.Service.Interfaces;
using webApi.Validators;
using WebApi.Models;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomersAsync()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(_mapper.Map<List<CustomerDto>>(customers));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        [HttpPost]
        public async Task<ActionResult<CreateCustomerDto>> CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            var customer = _mapper.Map<Customer>(createCustomerDto);
            var validator = new CustomerValidator();
            var validationResult = validator.Validate(customer);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var createdCustomer = await _customerService.CreateCustomerAsync(createCustomerDto);
            var createdCustomerDto = _mapper.Map<CustomerDto>(createdCustomer);
            return CreatedAtAction(nameof(GetCustomerByIdAsync), new { id = createdCustomerDto.Id }, createdCustomerDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCustomerDto>> UpdateCustomerAsync(int id, UpdateCustomerDto customerDto)
        {
            try
            {
                var updatedCustomer = await _customerService.UpdateCustomerAsync(id, customerDto);
                return Ok(_mapper.Map<UpdateCustomerDto>(updatedCustomer));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomerAsync(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
