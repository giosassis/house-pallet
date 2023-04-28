using FluentValidation;
using webApi.Data.Dtos;

namespace webApi.Validators
{
    public class PaymentMethodCreateValidator : AbstractValidator<CreatePaymentMethodDto>
    {
        public PaymentMethodCreateValidator()
        {
            RuleFor(x => x.PaymentMethodTypeId)
            .NotEmpty().WithMessage("Payment method type id is required.")
            .GreaterThan(0).WithMessage("Payment method type id must be greater than 0.");
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer id is required.")
                .GreaterThan(0).WithMessage("Customer id must be greater than 0.");
            RuleFor(x => x.PaymentDate)
                .NotEmpty().WithMessage("Payment date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Payment date cannot be in the future.");
            RuleFor(x => x.PaymentAmount)
                .NotEmpty().WithMessage("Payment amount is required.")
                .GreaterThan(0).WithMessage("Payment amount must be greater than 0.");
        }
    }
}
