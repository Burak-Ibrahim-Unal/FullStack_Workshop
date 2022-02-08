using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.IndividualCustomers.Commands
{
    public class CreateIndividualCustomerCommandValidator : AbstractValidator<CreateIndividualCustomerCommand>
    {
        public CreateIndividualCustomerCommandValidator()
        {
            //AOP
            RuleFor(b => b.FirstName).NotEmpty();
            RuleFor(b => b.FirstName).MinimumLength(2);
            RuleFor(b => b.LastName).NotEmpty();
            RuleFor(b => b.LastName).MinimumLength(2);
            RuleFor(b => b.NationalIdentity).NotEmpty();
            RuleFor(b => b.NationalIdentity).Length(11);
            RuleFor(b => b.CustomerId).NotEmpty();

        }
    }
}