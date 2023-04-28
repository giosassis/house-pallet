using System.ComponentModel.DataAnnotations;

namespace webApi.Data.Dtos
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? Material { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}
