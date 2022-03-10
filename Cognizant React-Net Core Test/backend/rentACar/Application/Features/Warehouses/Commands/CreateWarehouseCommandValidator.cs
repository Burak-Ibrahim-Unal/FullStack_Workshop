using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Warehouses.Commands
{
    public class CreateWarehouseCommandValidator : AbstractValidator<CreateWarehouseCommand>
    {
        public CreateWarehouseCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(200);

            RuleFor(c => c.LocationId)
                .NotEmpty();    


        }

    }
}