using AutoMapper;
using webApi.Data.Dtos;
using webApi.Data;
using webApi.Models;
using webApi.Repository.Interface;

namespace webApi.Repositories.Implementations
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IMapper _mapper;

        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _mapper = mapper;
        }

        public async Task<List<PaymentMethodDto>> GetAllPaymentMethodsAsync()
        {
            var paymentMethods = await _paymentMethodRepository.GetAllAsync();
            return _mapper.Map<List<PaymentMethodDto>>(paymentMethods);
        }

        public async Task<PaymentMethodDto> GetPaymentMethodByIdAsync(int id)
        {
            var paymentMethod = await _paymentMethodRepository.GetByIdAsync(id);
            return _mapper.Map<PaymentMethodDto>(paymentMethod);
        }

        public async Task<CreatePaymentMethodDto> CreatePaymentMethodAsync(CreatePaymentMethodDto paymentMethodCreateDto)
        {
            var paymentMethod = _mapper.Map<PaymentMethod>(paymentMethodCreateDto);

            paymentMethod.PaymentDate = DateTime.UtcNow;

            await _paymentMethodRepository.AddAsync(paymentMethod);
            return _mapper.Map<CreatePaymentMethodDto>(paymentMethod);
        }

        public async Task<UpdatePaymentMethodDto> UpdatePaymentMethodAsync(int id, UpdatePaymentMethodDto paymentMethodUpdateDto)
        {
            var paymentMethod = await _paymentMethodRepository.GetByIdAsync(id);
            if (paymentMethod == null)
            {
                return null;
            }
            _mapper.Map(paymentMethodUpdateDto, paymentMethod);
            await _paymentMethodRepository.UpdateAsync(paymentMethod);
            return _mapper.Map<UpdatePaymentMethodDto>(paymentMethod);
        }

        public async Task DeletePaymentMethodAsync(int id)
        {
            await _paymentMethodRepository.DeleteByIdAsync(id);
        }
    }
}
