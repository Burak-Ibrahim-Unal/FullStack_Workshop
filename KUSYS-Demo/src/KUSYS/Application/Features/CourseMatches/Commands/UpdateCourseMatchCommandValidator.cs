using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.CourseMatches.Commands
{
    public class UpdateCourseMatchCommandValidator : AbstractValidator<UpdateCourseMatchCommand>
    {
        public UpdateCourseMatchCommandValidator()
        {
            RuleFor(c => c.StudentId)
                            .NotEmpty();
            RuleFor(c => c.CourseId)
                            .NotEmpty();

        }
    }
}