using Application.Features.Students.Dtos;
using Core.Persistence.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;

namespace Application.Services.Repositories;

public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>, ISyncRepository<UserOperationClaim>
{
    Task<UserOperationClaimDto> GetUserOperationClaimByEmail(string email, CancellationToken cancellationToken = default);
}