using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands;

public class UpdateUserCommand : IRequest<UserUpdateDto>
{
    public UserRegistrationUpdateDto UserRegistrationUpdateDto { get; set; }

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserUpdateDto>
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

        public async Task<UserUpdateDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetAsync(x => x.Id == request.Id);

            if (userToUpdate == null)
                throw new BusinessException("User cannot found");

            _mapper.Map(userToUpdate, request);
            await _userRepository.UpdateAsync(userToUpdate);
            var updatedUser = _mapper.Map<UserUpdateDto>(userToUpdate);

            return updatedUser;
        }
    }

}