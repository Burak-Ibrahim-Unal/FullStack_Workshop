using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace Api.Entities
{
    public class AppUserRole : IdentityRole<int>
    {

        public AppUser User { get; set; }
        public AppRole Role { get; set; }

    }
}