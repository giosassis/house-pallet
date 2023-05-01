using System.ComponentModel.DataAnnotations;

namespace webApi.Data.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public int DeliveryAddressId { get; set; }
        public int PaymentMethodId { get; set; }
        public List<OrderItemDto>? OrderItems { get; set; }
    }
}
