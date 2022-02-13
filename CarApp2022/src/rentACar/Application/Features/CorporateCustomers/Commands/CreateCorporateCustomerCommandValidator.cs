using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.CorporateCustomers.Commands
{
    public class CreateCorporateCustomerCommandValidator : AbstractValidator<CreateCorporateCustomerCommand>
    {
        public CreateCorporateCustomerCommandValidator()
        {
            //AOP
            RuleFor(b => b.CompanyName)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(b => b.TaxNo)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(b => b.CustomerId).NotEmpty();

        }
    }
}