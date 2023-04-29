﻿namespace webApi.Data.Dtos
{
    public class DeliveryAddressReadDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? Street { get; set; }
        public int Number { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
