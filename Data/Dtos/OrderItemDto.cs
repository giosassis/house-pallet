using System.ComponentModel.DataAnnotations;
using webApi.Models;

namespace webApi.Data.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Products? ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
