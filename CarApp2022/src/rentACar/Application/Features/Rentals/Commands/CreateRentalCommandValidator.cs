using FluentValidation;

namespace Application.Features.Rentals.Commands;

public class CreateRentalCommandValidator : AbstractValidator<CreateRentalCommand>
{
    public CreateRentalCommandValidator()
    {
        RuleFor(c=>c.CarId).NotEmpty();
        RuleFor(c=>c.CustomerId).NotEmpty();
        RuleFor(c => c.RentalStartDate).GreaterThanOrEqualTo(DateTime.Now);
    }
}