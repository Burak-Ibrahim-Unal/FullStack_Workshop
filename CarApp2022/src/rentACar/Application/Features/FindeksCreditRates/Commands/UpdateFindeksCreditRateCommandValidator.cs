using FluentValidation;

namespace Application.Features.FindeksCreditRates.Commands;

public class UpdateFindeksCreditRateCommandValidator : AbstractValidator<UpdateFindeksCreditRateCommand>
{
    public UpdateFindeksCreditRateCommandValidator()
    {
        RuleFor(f => f.Score).GreaterThanOrEqualTo((short)0).LessThanOrEqualTo((short)1900);
    }
}