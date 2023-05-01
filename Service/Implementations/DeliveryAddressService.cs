using AutoMapper;
using webApi.Data.Dtos;
using webApi.Models;
using webApi.Repositories.Implementations;
using webApi.Repositories.Interfaces;
using webApi.Repository.Interface;
using webApi.Service.Interfaces;
using WebApi.Service.Interface;

namespace webApi.Service.Implementations
{
    public class DeliveryAddressService : IDeliveryAddressService
    {
        private readonly IMapper _mapper;
        IDeliveryAddressRepository _deliveryAddressRepository;

        public DeliveryAddressService(IMapper mapper, IDeliveryAddressRepository deliveryAddressRepository)
        {
            _mapper = mapper;
            _deliveryAddressRepository = deliveryAddressRepository;
        }

        public async Task<List<DeliveryAddressReadDto>> GetAllDeliveryAddressesAsync()
        {
            var deliveryAddresses = await _deliveryAddressRepository.GetAllDeliveryAddressesAsync();
            return _mapper.Map<List<DeliveryAddressReadDto>>(deliveryAddresses);
        }

        public async Task<DeliveryAddressReadDto> GetDeliveryAddressByIdAsync(int id)
        {
            var deliveryAddress = await _deliveryAddressRepository.GetDeliveryAddressByIdAsync(id);
            return _mapper.Map<DeliveryAddressReadDto>(deliveryAddress);
        }

        public async Task<DeliveryAddressCreateDto> CreateDeliveryAddressAsync(DeliveryAddressCreateDto deliveryAddressCreateDto)
        {
            // Verifica se já existe um endereço com o mesmo Id de usuário
            var existingAddress = await _deliveryAddressRepository.GetDeliveryAddressByIdAsync(deliveryAddressCreateDto.CustomerId);
            if (existingAddress != null)
            {
                throw new InvalidOperationException("Um endereço já foi cadastrado para este usuário.");
            }

            // Cria um objeto DeliveryAddress a partir do DTO
            var deliveryAddress = _mapper.Map<DeliveryAddress>(deliveryAddressCreateDto);

            // Salva o endereço no banco de dados
            await _deliveryAddressRepository.CreateDeliveryAddressAsync(deliveryAddress);

            // Retorna o DTO criado
            return _mapper.Map<DeliveryAddressCreateDto>(deliveryAddress);
        }


        public async Task UpdateDeliveryAddressAsync(int id, DeliveryAddressUpdateDto deliveryAddressUpdateDto)
        {
            var existingDeliveryAddress = await _deliveryAddressRepository.GetDeliveryAddressByIdAsync(id);
            if (existingDeliveryAddress == null)
            {
                //throw custom exception or return null
                return;
            }

            var updatedDeliveryAddress = _mapper.Map(deliveryAddressUpdateDto, existingDeliveryAddress);
            await _deliveryAddressRepository.UpdateDeliveryAddressAsync(updatedDeliveryAddress);
        }

        public async Task DeleteDeliveryAddressAsync(int id)
        {
            await _deliveryAddressRepository.DeleteDeliveryAddressAsync(id);
        }
    }
}
