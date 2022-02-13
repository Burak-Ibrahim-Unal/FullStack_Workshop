using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Colors.Commands
{
    public class CreateColorCommandValidator : AbstractValidator<CreateColorCommand>
    {
        public CreateColorCommandValidator()
        {
            //AOP
            RuleFor(b => b.Name)
                .NotEmpty()
                .MinimumLength(2);

        }
    }
}