using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Maintenances.Commands
{
    public class UpdateMaintenanceCommandValidator : AbstractValidator<UpdateMaintenanceCommand>
    {
        public UpdateMaintenanceCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.MaintenanceDate).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.CarId).NotEmpty();
        }
    }
}