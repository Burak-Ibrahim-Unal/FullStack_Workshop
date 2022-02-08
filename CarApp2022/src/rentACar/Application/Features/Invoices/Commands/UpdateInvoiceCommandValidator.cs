using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Invoices.Commands;
using FluentValidation;

namespace Application.Features.Invoices.Commands
{
    public class UpdateInvoiceCommandValidator : AbstractValidator<UpdateInvoiceCommand>
    {
        public UpdateInvoiceCommandValidator()
        {
            //AOP
            RuleFor(c => c.RentalStartDate).GreaterThanOrEqualTo(DateTime.Now).LessThanOrEqualTo(c => c.RentalEndDate);
            RuleFor(c => c.RentalEndDate).GreaterThan(c => c.RentalStartDate);
            RuleFor(b => Convert.ToInt32(b.TotalRentalDate)).GreaterThan(0);
            RuleFor(b => b.RentalPrice).GreaterThan(100);
        }
    }
}