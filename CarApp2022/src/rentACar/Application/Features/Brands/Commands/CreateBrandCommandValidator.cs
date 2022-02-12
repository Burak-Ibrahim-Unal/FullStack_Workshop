using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Brands.Commands
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            //AOP
            #region Version 1
            //RuleFor(b => b.Name).NotEmpty();
            //RuleFor(b => b.Name).MinimumLength(2); 
            #endregion

            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2);

        }
    }
}