using webApi.Data.Dtos;

namespace webApi.Repository.Interface
{
    public interface IPaymentMethodService
    {
        Task<List<PaymentMethodDto>> GetAllPaymentMethodsAsync();
        Task<PaymentMethodDto> GetPaymentMethodByIdAsync(int id);
        Task<CreatePaymentMethodDto> CreatePaymentMethodAsync(CreatePaymentMethodDto paymentMethod);
        Task<UpdatePaymentMethodDto> UpdatePaymentMethodAsync(int id, UpdatePaymentMethodDto paymentMethod);
        Task DeletePaymentMethodAsync(int id);
    }
}
