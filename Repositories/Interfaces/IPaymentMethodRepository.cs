using webApi.Models;

namespace webApi.Repository.Interface
{
    public interface IPaymentMethodRepository
    {
        Task<List<PaymentMethod>> GetAllAsync();
        Task<PaymentMethod> GetByIdAsync(int id);
        Task AddAsync(PaymentMethod paymentMethod);
        Task UpdateAsync(PaymentMethod paymentMethod);
        Task DeleteAsync(PaymentMethod paymentMethod);
        Task DeleteByIdAsync(int id);
    }
}
