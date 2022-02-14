using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Fuels.Commands
{
    public class CreateFuelCommandValidator : AbstractValidator<CreateFuelCommand>
    {
        public CreateFuelCommandValidator()
        {
            //AOP
            RuleFor(b => b.Name)
                .NotEmpty()
                .MinimumLength(2);
            
        }
    }
}