using Core.Utilities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands
{
    public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
    {
        public UpdateCarCommandValidator()
        {
            RuleFor(c => c.ModelYear)
                           .NotEmpty()
                           .GreaterThanOrEqualTo((short)1900)
                           .LessThan((short)(DateTime.Now.Year + 2));

            RuleFor(c => c.ModelId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();

            RuleFor(c => c.Plate)
                .NotEmpty()
                .Length(6, 9)
                .Must(StartWithNumber).WithMessage(Messages.CarPlateIsNotValid);
        }


        private bool StartWithNumber(string plate)
        {
            var firstTwo = plate.Substring(0, 2);
            int tmp = 0;
            bool result = int.TryParse(firstTwo, out tmp);
            return result;
        }
    }
}