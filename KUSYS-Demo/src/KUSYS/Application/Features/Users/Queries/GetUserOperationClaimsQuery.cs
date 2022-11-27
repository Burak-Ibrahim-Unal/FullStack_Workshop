using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Security.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries
{
    public class GetUserOperationClaimsQuery : IRequest<UserOperationClaimDto>
    {
        public string Email { get; set; }

        public class GetUserOperationClaimsQueryHandler : IRequestHandler<GetUserOperationClaimsQuery, UserOperationClaimDto>
        {
            IUserOperationClaimRepository _userOperationClaimRepository;
            IMapper _mapper;

            public GetUserOperationClaimsQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UserOperationClaimDto> Handle(GetUserOperationClaimsQuery request, CancellationToken cancellationToken)
            {
                var userOperationClaim = await _userOperationClaimRepository.GetUserOperationClaimByEmail(request.Email);

                return userOperationClaim;
            }

        }
    }
}