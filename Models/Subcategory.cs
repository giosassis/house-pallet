﻿using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
