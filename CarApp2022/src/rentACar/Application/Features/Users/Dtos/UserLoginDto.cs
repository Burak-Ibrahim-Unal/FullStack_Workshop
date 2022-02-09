using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Dtos
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public bool IsLoginSuccess { get; set; }

    }
}
