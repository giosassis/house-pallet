using System.ComponentModel.DataAnnotations;

namespace webApi.Data.Dtos
{
    public class UpdateSubcategoryDto
    {
        public class SubcategoryUpdateDto
        {
            [StringLength(100)]
            public string? Name { get; set; }

            public int CategoryId { get; set; }

        }
    }
}
