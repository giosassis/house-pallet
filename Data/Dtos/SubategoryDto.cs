using webApi.Models;

namespace webApi.Data.Dtos
{
    public class SubcategoryDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int CategoriaId { get; set; }
        public Category? Category { get; set; }

    }
}
