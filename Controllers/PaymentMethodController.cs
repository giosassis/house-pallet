using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApi.Data;
using webApi.Data.Dtos;
using webApi.Models;
using Microsoft.EntityFrameworkCore;
using webApi.Validators;
using webApi.Repository.Interface;
using webApi.Service.Implementations;
using webApi.Service.Interfaces;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IMapper _mapper;
        public PaymentMethodController(IPaymentMethodService paymentMethodService, IMapper mapper)
        {
            _paymentMethodService = paymentMethodService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PaymentMethodDto>>> GetAllPaymentMethodsAsync()
        {
            var paymentMethods = await _paymentMethodService.GetAllPaymentMethodsAsync();
            var paymentMethodDtos = _mapper.Map<List<PaymentMethodDto>>(paymentMethods);
            return Ok(paymentMethodDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethodDto>> GetPaymentMethodByIdAsync(int id)
        {
            var paymentMethod = await _paymentMethodService.GetPaymentMethodByIdAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            var paymentMethodDto = _mapper.Map<PaymentMethodDto>(paymentMethod);
            return Ok(paymentMethodDto);
        }

        [HttpPost]
        public async Task<ActionResult<CreatePaymentMethodDto>> CreatePaymentMethodAsync(CreatePaymentMethodDto paymentMethodCreateDto)
        {
            var createdPaymentMethod = await _paymentMethodService.CreatePaymentMethodAsync(paymentMethodCreateDto);
            return CreatedAtAction(nameof(GetPaymentMethodByIdAsync), new { id = createdPaymentMethod.Id }, createdPaymentMethod);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdatePaymentMethodDto>> UpdatePaymentMethodAsync(int id, UpdatePaymentMethodDto paymentMethodUpdateDto)
        {
            if (id != paymentMethodUpdateDto.PaymentMethodTypeId) return BadRequest();
            await _paymentMethodService.UpdatePaymentMethodAsync(id, paymentMethodUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeliveryAddressAsync(int id)
        {
            var paymentMethod = await _paymentMethodService.GetPaymentMethodByIdAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            await _paymentMethodService.DeletePaymentMethodAsync(id);
            return NoContent();
        }
    }
}