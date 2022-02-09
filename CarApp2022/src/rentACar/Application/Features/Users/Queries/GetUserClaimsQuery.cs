using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries
{
    public class GetUserClaimsQuery : IRequest<UserClaimsListDto>
    {
        public PageRequest? PageRequest { get; set; }

        public class GetUserClaimsQueryHandler : IRequestHandler<GetUserClaimsQuery, UserClaimsListDto>
        {
            IUserRepository _userRepository;
            IMapper _mapper;

            public GetUserClaimsQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<UserClaimsListDto> Handle(GetUserClaimsQuery request, CancellationToken cancellationToken)
            {
                var users = await _userRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedUsers = _mapper.Map<UserClaimsListDto>(users);
                return mappedUsers;
            }         
            
        }
    }
}