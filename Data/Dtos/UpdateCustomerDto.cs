using System.ComponentModel.DataAnnotations;

namespace webApi.Data.Dtos
{
    public class UpdateCustomerDto
    {
        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }

        [StringLength(14)]
        public string? CPF { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [StringLength(100, MinimumLength = 6)]
        public string? Password { get; set; }
    }
}
