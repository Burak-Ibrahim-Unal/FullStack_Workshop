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
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Name).MinimumLength(2);
            
        }
    }
}