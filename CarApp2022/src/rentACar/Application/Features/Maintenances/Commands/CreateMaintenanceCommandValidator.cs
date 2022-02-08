using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Maintenances.Commands
{
    public class CreateMaintenanceCommandValidator : AbstractValidator<CreateMaintenanceCommand>
    {
        public CreateMaintenanceCommandValidator()
        {
            RuleFor(c => c.MaintenanceDate).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.CarId).NotEmpty();

        }
    }
}