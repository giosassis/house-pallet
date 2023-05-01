using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models;

namespace webApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public int DeliveryAddressId { get; set; }
        [ForeignKey("DeliveryAddressId")]
        public DeliveryAddress? DeliveryAddress { get; set; }
        public int PaymentMethodId { get; set; }
        [ForeignKey("PaymentMethodId")]
        public PaymentMethod? PaymentMethod { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Products? Products { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
    }
}
