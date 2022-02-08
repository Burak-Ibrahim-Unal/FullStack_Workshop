using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CorporateCustomers.Commands;
using FluentValidation;

namespace Application.Features.CorporateCustomers.Commands
{
    public class UpdateCorporateCustomerCommandValidator : AbstractValidator<UpdateCorporateCustomerCommand>
    {
        public UpdateCorporateCustomerCommandValidator()
        {
            //AOP
            RuleFor(b => b.CompanyName).NotEmpty();
            RuleFor(b => b.CompanyName).MinimumLength(2);
            RuleFor(b => b.TaxNo).NotEmpty();
            RuleFor(b => b.TaxNo).MinimumLength(2);
            RuleFor(b => b.CustomerId).NotEmpty();
        }
    }
}