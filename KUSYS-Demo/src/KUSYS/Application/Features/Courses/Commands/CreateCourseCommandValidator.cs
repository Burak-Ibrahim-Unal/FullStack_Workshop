using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Courses.Commands
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(c => c.CourseId)
                            .NotEmpty()
                            .MinimumLength(2); 
            RuleFor(c => c.CourseName)
                            .NotEmpty()
                            .MinimumLength(4);
        }
    }
}