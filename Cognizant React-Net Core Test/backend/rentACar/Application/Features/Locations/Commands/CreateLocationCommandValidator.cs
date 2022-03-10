using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Locations.Commands
{
    public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
    {
        public CreateLocationCommandValidator()
        {
            RuleFor(c => c.Latitude)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(10);   
            
            RuleFor(c => c.Longitude)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(10);

        }
    }
}