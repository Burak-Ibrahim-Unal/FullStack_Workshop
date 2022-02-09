using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Mailing;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Utilities.Security.Hashing;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands
{
    public class LoginUserCommand : IRequest<UserLoginDto>
    {
        public UserForLoginDto LoginDto { get; set; }


        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserLoginDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public LoginUserCommandHandler(IUserRepository userRepository,
                IMapper mapper,
                UserBusinessRules userBusinessRules,
                IMailService mailService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UserLoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var createdUser = await _userRepository.GetAsync(u => u.Email == request.LoginDto.Email);

                if (createdUser == null) throw new BusinessException("user not found");

                if (HashingHelper.VerifyPasswordHash(request.LoginDto.Password, createdUser.PasswordHash,createdUser.PasswordSalt))
                {
                    throw new BusinessException("user password error");
                }
                return new UserLoginDto {
                    Email = request.LoginDto.Email,

                };
            }

        }

    }
}
