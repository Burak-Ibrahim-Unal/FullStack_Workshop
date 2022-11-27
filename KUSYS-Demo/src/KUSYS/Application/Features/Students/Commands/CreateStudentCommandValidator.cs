using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Students.Commands
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(c => c.FirstName)
                            .NotEmpty()
                            .MinimumLength(2);
            RuleFor(c => c.LastName)
                            .NotEmpty()
                            .MinimumLength(2);    

        }
    }
}