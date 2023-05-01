namespace WebApi.Repositories.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using webApi.Data;
    using webApi.Models;
    using webApi.Repository.Interface;

    #pragma warning disable SA1101 // PrefixLocalCallsWithThis

    public class DeliveryAddressRepository : IDeliveryAddressRepository
    {
    private readonly ContextDb _dbContext;

    public DeliveryAddressRepository(ContextDb dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<DeliveryAddress>> GetAllDeliveryAddressesAsync()
    {
        return await _dbContext.DeliveryAddresses.ToListAsync();
    }

    public async Task<DeliveryAddress> GetDeliveryAddressByIdAsync(int id)
    {
        return await _dbContext.DeliveryAddresses.FindAsync(id);
    }

    public async Task<DeliveryAddress> CreateDeliveryAddressAsync(DeliveryAddress deliveryAddress)
    {
        await _dbContext.DeliveryAddresses.AddAsync(deliveryAddress);
        await _dbContext.SaveChangesAsync();
        return deliveryAddress;
    }

    public async Task UpdateDeliveryAddressAsync(DeliveryAddress deliveryAddress)
    {
        _dbContext.DeliveryAddresses.Update(deliveryAddress);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteDeliveryAddressAsync(int id)
    {
        var deliveryAddress = await _dbContext.DeliveryAddresses.FindAsync(id);
        if (deliveryAddress != null)
        {
            _dbContext.DeliveryAddresses.Remove(deliveryAddress);
            await _dbContext.SaveChangesAsync();
        }
    }
}
}
