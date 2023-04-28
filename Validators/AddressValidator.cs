using FluentValidation;
using webApi.Data.Dtos;

public class DeliveryAddressCreateValidator : AbstractValidator<DeliveryAddressCreateDto>
{
    public DeliveryAddressCreateValidator()
    {
        RuleFor(x => x.Street)
            .NotNull().WithMessage("The street cannot be null.")
            .NotEmpty().WithMessage("The street cannot be empty.")
            .MaximumLength(200).WithMessage("The street cannot have more than 200 characters.");

        RuleFor(x => x.City)
            .NotNull().WithMessage("The city cannot be null.")
            .NotEmpty().WithMessage("The city cannot be empty.")
            .MaximumLength(100).WithMessage("The city cannot have more than 100 characters.");

        RuleFor(x => x.State)
            .NotNull().WithMessage("The state cannot be null.")
            .NotEmpty().WithMessage("The state cannot be empty.")
            .MaximumLength(100).WithMessage("The state cannot have more than 100 characters.");

        RuleFor(x => x.PostalCode)
            .NotNull().WithMessage("The postal code cannot be null.")
            .NotEmpty().WithMessage("The postal code cannot be empty.")
            .MaximumLength(10).WithMessage("The postal code cannot have more than 10 characters.");

        RuleFor(x => x.Country)
            .NotNull().WithMessage("The country cannot be null.")
            .NotEmpty().WithMessage("The country cannot be empty.")
            .MaximumLength(100).WithMessage("The country cannot have more than 100 characters.");

    }
}

public class DeliveryAddressUpdateValidator : AbstractValidator<DeliveryAddressUpdateDto>
{
    public DeliveryAddressUpdateValidator()
    {
        RuleFor(x => x.Street)
            .NotNull().WithMessage("The street cannot be null.")
            .NotEmpty().WithMessage("The street cannot be empty.")
            .MaximumLength(200).WithMessage("The street cannot have more than 200 characters.");

        RuleFor(x => x.City)
            .NotNull().WithMessage("The city cannot be null.")
            .NotEmpty().WithMessage("The city cannot be empty.")
            .MaximumLength(100).WithMessage("The city cannot have more than 100 characters.");

        RuleFor(x => x.State)
            .NotNull().WithMessage("The state cannot be null.")
            .NotEmpty().WithMessage("The state cannot be empty.")
            .MaximumLength(100).WithMessage("The state cannot have more than 100 characters.");

        RuleFor(x => x.PostalCode)
            .NotNull().WithMessage("The postal code cannot be null.")
            .NotEmpty().WithMessage("The postal code cannot be empty.")
            .MaximumLength(10).WithMessage("The postal code cannot have more than 10 characters.");

        RuleFor(x => x.Country)
            .NotNull().WithMessage("The country cannot be null.")
            .NotEmpty().WithMessage("The country cannot be empty.")
            .MaximumLength(100).WithMessage("The country cannot have more than 100 characters.");

    }
}
