using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using webApi.Data;
using webApi.Data.Dtos;
using webApi.Models;
using webApi.Validators;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;
        public CustomerController(ContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            var customer = _context.Customers.ToList();
            var customersDto = _mapper.Map<List<CustomerDto>>(customer);
            return Ok(customersDto);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound("Customer doesn't exists on database");
            var customersDto = _mapper.Map<CustomerDto>(customer);
            return Ok(customersDto);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerDto createCustomerDto)
        {
            Customer customer = _mapper.Map<Customer>(createCustomerDto);
            var validator = new CustomerValidator();
            ValidationResult result = validator.Validate(customer);

            if(!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            if (_context.Customers.Any(c => c.Cpf == createCustomerDto.Cpf))
            {
                return Conflict("Customer already exists.");
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] UpdateCustomerDto updateCustomerDto)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound("Customer doesn't exists on database");
            _mapper.Map(updateCustomerDto, customer);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound("Product doesn't exists on database");

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return NoContent();
        }
    }
}