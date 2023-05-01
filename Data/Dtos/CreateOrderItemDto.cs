using System.ComponentModel.DataAnnotations;

namespace webApi.Data.Dtos
{
    public class CreateOrderItemDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The ProductId field is required.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "The Quantity field is required.")]
        public int Quantity { get; set; }
    }
}
