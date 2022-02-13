using FluentValidation;

namespace Application.Features.CarDamages.Commands;

public class UpdateCarDamageCommandValidator : AbstractValidator<UpdateCarDamageCommand>
{
    public UpdateCarDamageCommandValidator()
    {
        RuleFor(cd => cd.Description)
            .NotEmpty()
            .MinimumLength(5);

        RuleFor(cd=>cd.CarId)
            .NotEmpty();

    }
}