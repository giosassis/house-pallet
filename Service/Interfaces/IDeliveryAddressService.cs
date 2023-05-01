namespace WebApi.Service.Interface
{
    using webApi.Models;
    using webApi.Data.Dtos;

#pragma warning disable SA1600 // Elements should be documented

    public interface IDeliveryAddressService
    {
        Task<List<DeliveryAddressReadDto>> GetAllDeliveryAddressesAsync();

        Task<DeliveryAddressReadDto> GetDeliveryAddressByIdAsync(int id);

        Task<DeliveryAddressCreateDto> CreateDeliveryAddressAsync(DeliveryAddressCreateDto deliveryAddressCreateDto);

        Task UpdateDeliveryAddressAsync(int id, DeliveryAddressUpdateDto deliveryAddressUpdateDto);

        Task DeleteDeliveryAddressAsync(int id);
    }
}
