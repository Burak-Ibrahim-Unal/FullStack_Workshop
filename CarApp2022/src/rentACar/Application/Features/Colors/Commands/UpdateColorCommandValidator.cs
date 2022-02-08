using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Colors.Commands
{
    public class UpdateColorCommandValidator : AbstractValidator<UpdateColorCommand>
    {
        public UpdateColorCommandValidator()
        {
            //AOP
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Name).MinimumLength(2);
            
        }
    }
}