﻿using System.ComponentModel.DataAnnotations;

namespace webApi.Data.Dtos
{
    public class CreateOrderDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The CustomerId field is required.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "The TotalPrice field is required.")]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "The OrderDate field is required.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "The DeliveryAddressId field is required.")]
        public int DeliveryAddressId { get; set; }

        [Required(ErrorMessage = "The PaymentMethodId field is required.")]
        public int PaymentMethodId { get; set; }
        public List<CreateOrderItemDto>? OrderItems { get; set; }
    }
}
