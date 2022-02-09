using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
