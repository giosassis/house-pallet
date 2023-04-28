using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webApi.Models;

namespace webApi.Data.Dtos
{
    public class CreateProductDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Material { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public int Stock { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

    }
}

