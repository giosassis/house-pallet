using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models;

namespace webApi.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public int PaymentMethodTypeId { get; set; }
        [ForeignKey("PaymentMethodTypeId")]
        public PaymentMethodType? PaymentMethodType { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentAmount { get; set; }

    }
}
