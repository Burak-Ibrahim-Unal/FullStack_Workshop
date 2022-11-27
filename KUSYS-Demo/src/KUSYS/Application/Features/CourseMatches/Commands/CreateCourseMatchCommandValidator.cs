using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.CourseMatches.Commands
{
    public class CreateCourseMatchCommandValidator : AbstractValidator<CreateCourseMatchCommand>
    {
        public CreateCourseMatchCommandValidator()
        {
            RuleFor(c => c.CourseId)
                            .NotEmpty();
            RuleFor(c => c.StudentId)
                            .NotEmpty();
        }
    }
}