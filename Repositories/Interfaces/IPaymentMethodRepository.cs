using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Repository.Interface
{
    public interface IPaymentMethodRepository
    {
        Task<PaymentMethod> GetPaymentMethodByIdAsync(int paymentMethodId);
        Task<List<PaymentMethod>> GetAllPaymentMethodsAsync();
        Task AddPaymentMethodAsync(PaymentMethod paymentMethod);
        Task UpdatePaymentMethodAsync(PaymentMethod paymentMethod);
        Task DeletePaymentMethodAsync(int paymentMethodId);
    }
}
