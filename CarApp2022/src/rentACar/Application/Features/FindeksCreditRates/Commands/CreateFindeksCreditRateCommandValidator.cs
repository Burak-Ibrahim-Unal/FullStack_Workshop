using FluentValidation;

namespace Application.Features.FindeksCreditRates.Commands;

public class CreateFindeksCreditRateCommandValidator : AbstractValidator<CreateFindeksCreditRateCommand>
{
    public CreateFindeksCreditRateCommandValidator()
    {
        RuleFor(f => f.Score).GreaterThanOrEqualTo((short)0).LessThanOrEqualTo((short)1900);
    }
}