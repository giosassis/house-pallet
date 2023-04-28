using System.ComponentModel.DataAnnotations;

namespace webApi.Data.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }
        public string TotalPriceFormatted { get; set; }
        public DateTime OrderDate { get; set; }
        public DeliveryAddressReadDto DeliveryAddress { get; set; }
        public PaymentMethodDto PaymentMethod { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
