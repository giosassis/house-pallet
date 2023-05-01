using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApi.Data.Dtos;
using webApi.Models;
using webApi.Repositories.Implementations;
using webApi.Repository.Interface;
using webApi.Service.Implementations;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderItemController(IOrderItemService orderItemService, IMapper mapper)
        {
            _orderItemService = orderItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderItemDto>>> GetAllOrderItemAsync()
        {
            var orderItem = await _orderItemService.GetAllOrderItemsAsync();
            var orderItemReadDtos = _mapper.Map<List<OrderItemDto>>(orderItem);
            return Ok(orderItemReadDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDto>> GetOrderItemByIdAsync(int id)
        {
            var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            var orderItemReadDto = _mapper.Map<OrderItemDto>(orderItem);
            return Ok(orderItemReadDto);
        }

        [HttpPost]
        public async Task<ActionResult<CreateOrderItemDto>> CreatePaymentMethodAsync(CreateOrderItemDto createOrderItemDto)
        {
            var createOrderItem = await _orderItemService.CreateOrderItemAsync(createOrderItemDto);
            return CreatedAtAction(nameof(GetOrderItemByIdAsync), new { id = createOrderItem.Id }, createOrderItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateOrderItemDto>> UpdateDeliveryAddressAsync(int id, UpdateOrderItemDto updateItemOrderDto)
        {
            if (id != updateItemOrderDto.Id) return BadRequest();
            await _orderItemService.UpdateOrderItemAsync(id, updateItemOrderDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeliveryAddressAsync(int id)
        {
            var deliveryAddress = await _orderItemService.GetOrderItemByIdAsync(id);
            if (deliveryAddress == null)
            {
                return NotFound();
            }

            await _orderItemService.DeleteOrderItemAsync(id);
            return NoContent();
        }
    }
}
