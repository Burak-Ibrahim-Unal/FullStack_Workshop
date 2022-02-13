using Application.Features.Auths.Rules;
using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands
{
    public class RegisterUserCommand : IRequest<CreateUserDto>
    {
        public UserForRegisterDto RegisterDto { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<RegisterUserCommand, CreateUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IAuthService _authService;


            public CreateUserCommandHandler(
                IUserRepository userRepository,
                IMapper mapper,
                AuthBusinessRules authBusinessRules,
                IAuthService _authService
            )
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _authBusinessRules = authBusinessRules;
                _authService = _authService;
            }

            public async Task<CreateUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.CheckEmailAbsence(request.RegisterDto.Email);

                var userToAdd = _mapper.Map<User>(request.RegisterDto);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.RegisterDto.Password, out passwordHash, out passwordSalt);
                userToAdd.PasswordSalt = passwordSalt;
                userToAdd.PasswordHash = passwordHash;
                userToAdd.Status = true;

                var createdUser = await _userRepository.AddAsync(userToAdd);
                var userToReturn = _mapper.Map<CreateUserDto>(createdUser);
                return userToReturn;
            }
        }
    }
}
