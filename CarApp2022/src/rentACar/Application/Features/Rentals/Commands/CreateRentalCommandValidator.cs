using FluentValidation;

namespace Application.Features.Rentals.Commands.CreateRental;

public class CreateRentalCommandValidator : AbstractValidator<CreateRentalCommand>
{
    public CreateRentalCommandValidator()
    {
        RuleFor(c=>c.CarId).NotEmpty();
        RuleFor(c=>c.CustomerId).NotEmpty();
        RuleFor(c => c.RentStartDate).GreaterThanOrEqualTo(DateTime.Now).LessThanOrEqualTo(c => c.RentEndDate);
        RuleFor(c => c.RentEndDate).GreaterThan(c => c.RentStartDate);
    }
}