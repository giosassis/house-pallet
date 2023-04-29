using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApi.Data;
using webApi.Data.Dtos;
using webApi.Models;
using Microsoft.EntityFrameworkCore;
using webApi.Validators;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentMethodController : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;
        public PaymentMethodController(ContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PaymentMethodDto>> GetAllPaymentMethods()
        {
            var paymentMethods = _context.PaymentMethods
                .Include(pm => pm.Customer)
                .Include(pm => pm.PaymentMethodType)
                .ToList();

            var paymentMethodDto = paymentMethods.Select(pm => new PaymentMethodDto
            {
                Id = pm.Id,
                CustomerId = pm.Customer!.Id,
                PaymentDate = pm.PaymentDate,
                PaymentAmmount = pm.PaymentAmount
            }).ToList();

            return Ok(paymentMethodDto);
        }

        [HttpGet("{id}")]
        public ActionResult<PaymentMethodDto> GetPaymentMethodById(int id) 
        {
            var paymentMethod = _context.PaymentMethods.Find(id);
            if (paymentMethod == null) return NotFound();
            var paymentMethodReadDto = _mapper.Map<PaymentMethodDto>(paymentMethod);
            return Ok(paymentMethodReadDto);

        }

        [HttpPost]
        public ActionResult<PaymentMethodDto> PostPaymentMethod([FromBody] CreatePaymentMethodDto paymentMethodCreateDto)
        {


            var paymentMethod = _mapper.Map<PaymentMethod>(paymentMethodCreateDto);
            _context.PaymentMethods.Add(paymentMethod);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPaymentMethodById), new { id = paymentMethod.Id }, paymentMethod);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdatePaymentMethodDto paymentMethodUpdateDto)
        {
            var paymentMethod = _context.PaymentMethods.Find(id);
            if (paymentMethod == null) return NotFound();
            _mapper.Map(paymentMethodUpdateDto, paymentMethod);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var paymentMethod = _context.PaymentMethods.Find(id);
            if (paymentMethod == null) return NotFound();
            _context.PaymentMethods.Remove(paymentMethod);
            _context.SaveChanges();
            return NoContent();
        }
    }
}