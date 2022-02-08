using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Transmissions.Commands
{
    public class CreateTransmissionCommandValidator : AbstractValidator<CreateTransmissionCommand>
    {
        public CreateTransmissionCommandValidator()
        {
            //AOP
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Name).MinimumLength(2);
            
        }
    }
}