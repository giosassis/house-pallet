﻿namespace webApi.Data.Dtos
{
    public class PaymentMethodDto
    {
        public int Id { get; set; }
        public int PaymentMethodTypeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentAmmount { get; set; }
    }
}
