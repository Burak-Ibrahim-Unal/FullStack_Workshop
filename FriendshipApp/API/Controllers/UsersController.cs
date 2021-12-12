using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _datacontext;

        public UsersController(DataContext datacontext)
        {
            _datacontext = datacontext;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _datacontext.Users.ToListAsync();
            return users;
        }

        [HttpGet("{id}")] // api/users/1
        public async Task<ActionResult<AppUser>> GetUserById(int id)
        {
            var user = await _datacontext.Users.FindAsync(id);
            return user;
        }
    }
}