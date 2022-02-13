using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Brands.Commands
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            //AOP
            RuleFor(c => c.Name)
                  .NotEmpty()
                  .MinimumLength(2);

        }
    }
}