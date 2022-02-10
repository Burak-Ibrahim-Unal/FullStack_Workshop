using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
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
    public class CreateUserCommand : IRequest<CreateUserDto>
    {
        public UserForRegisterDto RegisterDto { get; set; }


        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserDto>
        {
           private readonly IUserRepository _userRepository;
           private readonly IMapper _mapper;
           private readonly UserBusinessRules _userBusinessRules;

            public CreateUserCommandHandler(IUserRepository userRepository,
                IMapper mapper,
                UserBusinessRules userBusinessRules,
                IMailService mailService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<CreateUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var mappedUser = _mapper.Map<User>(request);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.RegisterDto.Password,out passwordHash,out passwordSalt);

                mappedUser.PasswordSalt = passwordSalt;
                mappedUser.PasswordHash = passwordHash;

                var createdUser = await _userRepository.AddAsync(mappedUser);
                var userDtoToReturn = _mapper.Map<CreateUserDto>(createdUser);

                return userDtoToReturn;
            }

        }

    }
}
