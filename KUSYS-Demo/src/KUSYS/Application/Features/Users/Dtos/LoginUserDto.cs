using Core.Security.Entities;
using Core.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Dtos
{
    public class LoginUserDto
    {        
        public AccessToken AccessToken { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
