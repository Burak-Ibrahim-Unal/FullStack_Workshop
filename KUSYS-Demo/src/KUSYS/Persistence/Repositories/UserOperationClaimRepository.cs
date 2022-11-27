using Application.Features.Courses.Dtos;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Domain.Entites;
using Nest;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
    {

        public UserOperationClaimRepository(BaseDbContext context) : base(context)
        {

        }

        public Task<UserOperationClaimDto> GetUserOperationClaimByEmail(string email, CancellationToken cancellationToken)
        {
            var result = from uoc in Context.UserOperationClaims
                         join uc in Context.OperationClaims on uoc.OperationClaimId equals uc.Id
                         join u in Context.User on uoc.UserId equals u.Id
                         where u.Email == email

                         select new UserOperationClaimDto
                         {
                             Email = u.Email,
                             OperationClaimName = uc.Name,
                         };

            return Task.FromResult(result.FirstOrDefault());
        }
    }
}
