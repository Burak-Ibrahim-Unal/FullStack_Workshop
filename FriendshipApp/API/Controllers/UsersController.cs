using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {

        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return Ok(await _userRepository.GetUsersAsync());
        }

        [HttpGet("{username}")] // api/users/1
        public async Task<ActionResult<AppUser>> GetUserByName(string username)
        {
            return await _userRepository.GetUserByNameAsync(username);
        }

        [HttpGet("{id:int}")] // api/users/1
        public async Task<ActionResult<AppUser>> GetUserById(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);

        }
    }
}