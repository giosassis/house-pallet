using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApi.Data;
using webApi.Data.Dtos;
using webApi.Models;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly ContextDb _context;
        private readonly IMapper _mapper;

        public OrderItemController(ContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrdersItems()
        {
            var orderItem = _context.OrderItems.ToList();
            var orderItemDtos = _mapper.Map<IEnumerable<OrderItemDto>>(orderItem);
            return Ok(orderItemDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderItem> GetOrderOrdersItemsById(int id)
        {
            var orderItem = _context.OrderItems.Find(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            var orderItemDto = _mapper.Map<OrderItemDto>(orderItem);
            return Ok(orderItemDto);
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemDto>> CreateOrdersItems(CreateOrderItemDto createOrderItemDto)
        {
            var orderItem = _mapper.Map<Order>(createOrderItemDto);
            await _context.SaveChangesAsync();

            var orderItemDto = _mapper.Map<OrderItemDto>(orderItem);
            return CreatedAtAction(nameof(GetOrderOrdersItemsById), new { id = orderItem.Id }, orderItemDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrdersItems(int id, UpdateOrderDto updateOrderDto)
        {
            var orderItem = _context.OrderItems.Find(id);
            if (orderItem == null) return NotFound();

            _mapper.Map(updateOrderDto, orderItem);
            _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrdersItems(int id)
        {
            var orderItem = _context.OrderItems.Find(id);
            if (orderItem == null) return NotFound();

            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
