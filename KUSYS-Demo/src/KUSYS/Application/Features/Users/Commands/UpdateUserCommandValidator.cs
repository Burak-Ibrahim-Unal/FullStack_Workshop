using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Users.Commands
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            //AOP
            RuleFor(u => u.UserRegistrationUpdateDto.FirstName).NotEmpty();
            RuleFor(u => u.UserRegistrationUpdateDto.LastName).NotEmpty();
            RuleFor(u => u.UserRegistrationUpdateDto.Email).NotEmpty();
            RuleFor(u => u.UserRegistrationUpdateDto.Password).NotEmpty();
            
        }
    }
}