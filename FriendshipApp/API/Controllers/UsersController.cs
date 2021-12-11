using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly DataContext _datacontext;

        public UsersController(DataContext datacontext)
        {
            _datacontext = datacontext;

        }

        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            var users = _datacontext.Users.ToList();
            return users;
        }

        [HttpGet("{id}")] // api/users/1
        public ActionResult<AppUser> GetUserById(int id)
        {
            var user = _datacontext.Users.Find(id);
            return user;
        }
    }
}