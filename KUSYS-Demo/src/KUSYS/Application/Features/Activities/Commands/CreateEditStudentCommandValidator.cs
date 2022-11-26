using System.Threading;
using System.Threading.Tasks;
using Domain.Entites;
using FluentValidation;
using MediatR;

namespace Application.Features.Activities.Commands
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty();
            RuleFor(a => a.LastName).NotEmpty();
            RuleFor(a => a.BirthDate).NotEmpty();

        }
    }
}