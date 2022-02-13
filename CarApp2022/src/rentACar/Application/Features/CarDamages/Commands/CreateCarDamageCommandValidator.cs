using FluentValidation;

namespace Application.Features.CarDamages.Commands;

public class CreateCarDamageCommandValidator : AbstractValidator<CreateCarDamageCommand>
{
    public CreateCarDamageCommandValidator()
    {
        RuleFor(cd => cd.Description)
            .NotEmpty()
            .MinimumLength(5);

        RuleFor(cd=>cd.CarId)
            .NotEmpty();

    }
}