using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Utilities;
using Domain.Entites;
using MediatR;

namespace Application.Features.Users.Commands;

public class UpdateUserCommand : IRequest<UpdateUserDto>
{
    public UserRegistrationUpdateDto UserRegistrationUpdateDto { get; set; }

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserDto>
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private UserBusinessRules _userBusinessRules;


        public UpdateUserHandler(UserBusinessRules userBusinessRules, IUserRepository userRepository, IMapper mapper)
        {
            _userBusinessRules = userBusinessRules;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UpdateUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetAsync(x => x.Id == request.UserRegistrationUpdateDto.Id);

            if (userToUpdate == null) throw new BusinessException(Messages.UserDoesNotExist);

            var mapperUser = _mapper.Map<User>(request);
            var updatedUser = await _userRepository.UpdateAsync(mapperUser);

            var userToReturn = _mapper.Map<UpdateUserDto>(updatedUser);
            return userToReturn;
        }
    }

}