﻿namespace WebApi.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Customer Table.
    /// </summary>
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Cpf { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Password { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}
