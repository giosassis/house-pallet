using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using webApi.Data;
using webApi.Data.Dtos;
using webApi.Models;
using webApi.Validators;
using WebApi.Service.Interface;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryAddressController : ControllerBase
    {
        private readonly IDeliveryAddressService _deliveryAddressService;
        private readonly IMapper _mapper;
        public DeliveryAddressController(IMapper mapper, IDeliveryAddressService deliveryAddressService)
        {
            _deliveryAddressService = deliveryAddressService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<DeliveryAddressReadDto>>> GetAllDeliveryAddressesAsync()
        {
            var deliveryAddresses = await _deliveryAddressService.GetAllDeliveryAddressesAsync();
            var deliveryAddressReadDtos = _mapper.Map<List<DeliveryAddressReadDto>>(deliveryAddresses);
            return Ok(deliveryAddressReadDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryAddressReadDto>> GetDeliveryAddressByIdAsync(int id)
        {
            var deliveryAddress = await _deliveryAddressService.GetDeliveryAddressByIdAsync(id);
            if (deliveryAddress == null)
            {
                return NotFound();
            }

            var deliveryAddressReadDto = _mapper.Map<DeliveryAddressReadDto>(deliveryAddress);
            return Ok(deliveryAddressReadDto);
        }

        [HttpPost]
        public async Task<ActionResult<DeliveryAddressCreateDto>> CreateDeliveryAddressAsync(DeliveryAddressCreateDto deliveryAddressCreateDto)
        {
            var deliveryAddress = _mapper.Map<DeliveryAddressCreateDto>(deliveryAddressCreateDto);
            await _deliveryAddressService.CreateDeliveryAddressAsync(deliveryAddress);
            var deliveryAddressReadDto = _mapper.Map<DeliveryAddressReadDto>(deliveryAddress);
            return CreatedAtAction(nameof(GetDeliveryAddressByIdAsync), new { deliveryAddress.Id }, deliveryAddressReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DeliveryAddressUpdateDto>> UpdateDeliveryAddressAsync(int id, DeliveryAddressUpdateDto deliveryAddressUpdateDto)
        {
            if (id != deliveryAddressUpdateDto.Id) return BadRequest();
            await _deliveryAddressService.UpdateDeliveryAddressAsync(id, deliveryAddressUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeliveryAddressAsync(int id)
        {
            var deliveryAddress = await _deliveryAddressService.GetDeliveryAddressByIdAsync(id);
            if (deliveryAddress == null)
            {
                return NotFound();
            }

            await _deliveryAddressService.DeleteDeliveryAddressAsync(id);
            return NoContent();
        }
    }
}