using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Utilities;
using Core.Security.Hashing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Users.Dtos;
using Core.Security.Entities;

namespace Application.Features.Auths.Commands
{
    public class LoginUserCommand : IRequest<LoginUserDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IAuthService _authService;


            public LoginUserCommandHandler(
                IUserRepository userRepository,
                AuthBusinessRules authBusinessRules,
                IAuthService authService
            )
            {
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
                _authService = authService;
            }

            public async Task<LoginUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.CheckEmailPresence(request.UserForLoginDto.Email);

                User? user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);
                await _authBusinessRules.CheckPasswords(user.Id, request.UserForLoginDto.Password);

                var accessToken = await _authService.CreateAccessToken(user);

                return new LoginUserDto
                {
                    AccessToken = accessToken
                };
            }
        }
    }
}
