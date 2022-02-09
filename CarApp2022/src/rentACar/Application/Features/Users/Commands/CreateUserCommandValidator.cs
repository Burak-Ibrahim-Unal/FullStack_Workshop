using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Users.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            //AOP
            RuleFor(u => u.RegisterDto.FirstName).NotEmpty();
            RuleFor(u => u.RegisterDto.LastName).NotEmpty();
            RuleFor(u => u.RegisterDto.Password).NotEmpty();
            RuleFor(u => u.RegisterDto.Email).NotEmpty();
            
        }
    }
}