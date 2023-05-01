using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApi.Data.Dtos;
using webApi.Repository.Interface;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAllOrdersAsync()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            var orderReadDtos = _mapper.Map<List<OrderDto>>(orders);
            return Ok(orderReadDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderByIdAsync(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            var orderReadDto = _mapper.Map<OrderDto>(order);
            return Ok(orderReadDto);
        }

        [HttpPost]
        public async Task<ActionResult<CreateOrderDto>> CreateOrderAsync(CreateOrderDto orderCreateDto)
        {
            var order = _mapper.Map<CreateOrderDto>(orderCreateDto);
            await _orderService.CreateOrderAsync(order);

            var orderReadDto = _mapper.Map<CreateOrderDto>(order);
            return CreatedAtRoute(nameof(GetOrderByIdAsync), new { id = orderReadDto.Id }, orderReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateOrderDto>> UpdateDeliveryAddressAsync(int id, UpdateOrderDto updateOrderDto)
        {
            if (id != updateOrderDto.Id) return BadRequest();
            await _orderService.UpdateOrderAsync(id, updateOrderDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeliveryAddressAsync(int id)
        {
            var deliveryAddress = await _orderService.GetOrderByIdAsync(id);
            if (deliveryAddress == null)
            {
                return NotFound();
            }

            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
