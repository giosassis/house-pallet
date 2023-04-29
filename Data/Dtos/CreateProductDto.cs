using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webApi.Models;

namespace webApi.Data.Dtos
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "The Material field is required.")]
        public string Material { get; set; }

        [Required(ErrorMessage = "The Color field is required.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "The Size field is required.")]
        public string Size { get; set; }

        [Required(ErrorMessage = "The Stock field is required.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "The CategoryId field is required.")]
        public int CategoryId { get; set; }

    }
}

