using System.ComponentModel.DataAnnotations;

namespace webApi.Data.Dtos
{
    public class CreateSubcategoryDto
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

    }
}
