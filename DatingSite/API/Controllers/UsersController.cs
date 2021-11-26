using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public readonly DataContext Context;
        public UsersController(DataContext context)
        {
            this.Context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            return Context.Users.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUsers(int id)
        {
            return Context.Users.Find(id);
        }
    }
}