using System.ComponentModel.DataAnnotations;

namespace webApi.Data.Dtos
{
    public class CreatePaymentMethodDto
    {
        public int Id { get; set; }
        [Required]
        public int PaymentMethodTypeId { get; set; }
        public int CustomerId { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public decimal PaymentAmount { get; set; }
    }
}
