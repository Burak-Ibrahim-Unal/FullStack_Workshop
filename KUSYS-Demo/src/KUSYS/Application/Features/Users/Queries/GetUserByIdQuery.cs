using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using Domain.Entites;
using MediatR;

namespace Application.Features.Users.Queries;

public class GetUserByIdQuery : IRequest<User>
{
    public int Id { get; set; }

    public class GetUserByIdResponseHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRules;

        public GetUserByIdResponseHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _userBusinessRules = userBusinessRules;
        }


        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserCanNotBeEmptyWhenSelected(request.Id);

            var user = await _userRepository.GetAsync(b => b.Id == request.Id);
            return user;
        }
    }
}