using System.Collections.Generic;
using System.Threading.Tasks;
using webApi.Models;

namespace webApi.Repository.Interface
{
    public interface IDeliveryAddressRepository
    {
        Task<List<DeliveryAddress>> GetAllDeliveryAddressesAsync();
        Task<DeliveryAddress> GetDeliveryAddressByIdAsync(int id);
        Task<DeliveryAddress> CreateDeliveryAddressAsync(DeliveryAddress deliveryAddress);
        Task UpdateDeliveryAddressAsync(DeliveryAddress deliveryAddress);
        Task DeleteDeliveryAddressAsync(int id);
    }
}
