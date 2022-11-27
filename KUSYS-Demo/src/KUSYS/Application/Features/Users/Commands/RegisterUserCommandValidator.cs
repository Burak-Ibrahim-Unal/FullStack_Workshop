using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Users.Commands.RegisterUser;
using FluentValidation;

namespace Application.Features.Users.Commands
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(u => u.RegisterDto.FirstName)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(u => u.RegisterDto.LastName)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(u => u.RegisterDto.Password).NotEmpty();

            RuleFor(u => u.RegisterDto.Email)
                .NotEmpty()
                .EmailAddress();

        }
    }
}