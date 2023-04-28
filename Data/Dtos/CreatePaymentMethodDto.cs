using System.ComponentModel.DataAnnotations;

namespace webApi.Data.Dtos
{
    public class CreatePaymentMethodDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int PaymentMethodTypeId { get; set; }
        public int CustomerId { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public int PaymentAmount { get; set; }
    }
}
