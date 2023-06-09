﻿using System.ComponentModel.DataAnnotations;

namespace webApi.Data.Dtos
{
    public class UpdateOrderItemDto
    {
        [Required(ErrorMessage = "The Id field is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The ProductId field is required.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "The Quantity field is required.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        public decimal Price { get; set; }
    }
}
