using System.ComponentModel.DataAnnotations;

namespace webApi.Data.Dtos
{
    public class CreateCategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must have {1} characters or less.")]
        public string? Name { get; set; }
    }
}
