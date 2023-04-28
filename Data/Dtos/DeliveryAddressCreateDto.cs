using System.ComponentModel.DataAnnotations;

namespace webApi.Data.Dtos
{
    public class DeliveryAddressCreateDto
    {
        [Required(ErrorMessage = "The CustomerId field is required.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "The Street field is required.")]
        [MaxLength(100, ErrorMessage = "The Street field can have at most 100 characters.")]
        public string? Street { get; set; }

        [Required(ErrorMessage = "The City field is required.")]
        [MaxLength(50, ErrorMessage = "The City field can have at most 50 characters.")]
        public string? City { get; set; }

        [Required(ErrorMessage = "The State field is required.")]
        [MaxLength(50, ErrorMessage = "The State field can have at most 50 characters.")]
        public string? State { get; set; }

        [Required(ErrorMessage = "The PostalCode field is required.")]
        [MaxLength(10, ErrorMessage = "The PostalCode field can have at most 10 characters.")]
        public string? PostalCode { get; set; }

        [Required(ErrorMessage = "The Country field is required.")]
        [MaxLength(50, ErrorMessage = "The Country field can have at most 50 characters.")]
        public string? Country { get; set; }
        
    }
}
