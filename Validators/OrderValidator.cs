using FluentValidation;
using webApi.Data.Dtos;

public class OrderValidator : AbstractValidator<CreateOrderDto>
{
    public OrderValidator()
    {
        RuleFor(o => o.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required.");

        RuleFor(o => o.TotalPrice)
            .GreaterThan(0).WithMessage("TotalPrice must be greater than zero.");

        RuleFor(o => o.OrderDate)
            .NotEmpty().WithMessage("OrderDate is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("OrderDate must be in the past.");

        RuleFor(o => o.DeliveryAddressId)
            .NotEmpty().WithMessage("DeliveryAddressId is required.");

        RuleFor(o => o.PaymentMethodId)
            .NotEmpty().WithMessage("PaymentMethodId is required.");

    }
}

public class OrderItemValidator : AbstractValidator<OrderItemDto>
{
    public OrderItemValidator()
    {
        RuleFor(oi => oi.ProductId)
            .NotEmpty().WithMessage("ProductId is required.");

        RuleFor(oi => oi.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

        RuleFor(oi => oi.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");
    }
}
