namespace webApi.Data.Dtos
{
    public class UpdatePaymentMethodDto
    {
        public string? Name { get; set; }
        public int CustomerId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentAmmount { get; set; }
    }
}
