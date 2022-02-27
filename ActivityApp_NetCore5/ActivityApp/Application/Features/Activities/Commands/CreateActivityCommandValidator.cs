using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Persistence.Contexts;

namespace Application.Features.Activities.Commands
{
    public class ActivityValidator : AbstractValidator<Activity>
    {
        public ActivityValidator()
        {
            RuleFor(a => a.Title).NotEmpty();
            RuleFor(a => a.Description).NotEmpty();
            RuleFor(a => a.Date).NotEmpty();
            RuleFor(a => a.Category).NotEmpty();
            RuleFor(a => a.City).NotEmpty();
            RuleFor(a => a.Venue).NotEmpty();
        }
    }
}