﻿
namespace webApi.Data.Dtos
{
    public class ProductsDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? Material { get; set; }
        public string? ImageURL { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public int Stock { get; set; }
    }
}
