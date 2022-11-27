using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Dtos
{
    public class UserOperationClaimDto
    {
        public string Email { get; set; }
        public string OperationClaimName { get; set; }

    }
}
