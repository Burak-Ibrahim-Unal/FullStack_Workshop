using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace Api.Entities
{
    public class AppUserRole : IdentityRole<int>
    {

        public AppUser User { get; set; }
        public int UserId { get; set; }
        public AppRole Role { get; set; }
        public int RoleId { get; set; }

    }
}