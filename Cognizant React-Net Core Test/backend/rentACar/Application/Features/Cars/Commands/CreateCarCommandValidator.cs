using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {

            RuleFor(c => c.Location)
                .NotEmpty();

            RuleFor(c => c.WarehouseId)
                .NotEmpty();
        }
    }
}