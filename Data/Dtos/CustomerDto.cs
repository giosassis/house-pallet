namespace webApi.Data.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
