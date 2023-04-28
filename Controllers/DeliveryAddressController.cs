using AutoMapper;
using FluentValidation;
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
    public class DeliveryAddressController : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;
        public DeliveryAddressController(ContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDeliveryAddresses()
        {
            var address = _context.DeliveryAddresses.ToList();
            var addressDto = _mapper.Map<List<DeliveryAddressReadDto>>(address);
            return Ok(addressDto);
        }

        [HttpGet("{id}")]
        public ActionResult<DeliveryAddress> GetDeliveryAddressById(int id)
        {
            var address = _context.DeliveryAddresses.Find(id);
            if (address == null) return NotFound();
            var addressDto = _mapper.Map<DeliveryAddressReadDto>(address);
            return Ok(addressDto);
        }

        [HttpPost]
        public IActionResult CreateAddress([FromBody] DeliveryAddressCreateDto deliveryAddressCreateDto)
        {
            DeliveryAddress address = _mapper.Map<DeliveryAddress>(deliveryAddressCreateDto);

            var validator = new DeliveryAddressCreateValidator();
            ValidationResult result = validator.Validate(deliveryAddressCreateDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            _context.DeliveryAddresses.Add(address);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetDeliveryAddressById), new { id = address.Id }, address);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAddress(int id, [FromBody] DeliveryAddressUpdateDto deliveryAddressUpdateDto)
        {
            var address = _context.DeliveryAddresses.Find(id);

            var validator = new DeliveryAddressUpdateValidator();
            ValidationResult result = validator.Validate(deliveryAddressUpdateDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }


            if (address == null) return NotFound();
            _mapper.Map(deliveryAddressUpdateDto, address);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(int id)
        {
            var address = _context.DeliveryAddresses.Find(id);
            if (address == null) return NotFound();

            _context.DeliveryAddresses.Remove(address);
            _context.SaveChanges();
            return NoContent();
        }
    }
}