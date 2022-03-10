using Core.Utilities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Commands
{
    public class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
    {
        public UpdateVehicleCommandValidator()
        {

            RuleFor(c => c.CarId)
                .NotEmpty();

            RuleFor(c => c.Make)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(c => c.Model)
                .NotEmpty();

            RuleFor(c => c.YearModel)
                .NotEmpty()
                .GreaterThanOrEqualTo((short)1900)
                .LessThanOrEqualTo((short)(DateTime.Now.Year + 2));

            RuleFor(c => c.Price)
                .NotEmpty()
                .GreaterThanOrEqualTo((short)0);

    }
}
}