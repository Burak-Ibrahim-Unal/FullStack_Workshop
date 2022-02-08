using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Fuels.Commands
{
    public class UpdateFuelCommandValidator : AbstractValidator<UpdateFuelCommand>
    {
        public UpdateFuelCommandValidator()
        {
            //AOP
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Name).MinimumLength(2);
            
        }
    }
}