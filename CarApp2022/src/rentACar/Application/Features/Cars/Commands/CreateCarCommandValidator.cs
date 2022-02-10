using Core.Utilities;
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
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelId).NotEmpty();
            RuleFor(c => c.ModelId).GreaterThan(0);
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ColorId).GreaterThan(0);
            RuleFor(c => c.Plate).NotEmpty();
            RuleFor(c => c.Plate).Length(6, 9);
            RuleFor(c => c.Plate).Must(StartWithNumber)
                .WithMessage(Messages.CarPlateIsNotValid);
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