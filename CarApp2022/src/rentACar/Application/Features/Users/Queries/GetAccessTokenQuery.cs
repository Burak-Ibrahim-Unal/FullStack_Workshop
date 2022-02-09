using Core.Security.Jwt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries
{
    public class GetAccessTokenQuery : IRequest<AccessToken>
    {
        public class GetAccessTokenQueryHandler : IRequestHandler<GetAccessTokenQuery, AccessToken>
        {
            public Task<AccessToken> Handle(GetAccessTokenQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

    }
}
