using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BugController : BaseApiController
    {
        public readonly DataContext Context;
        public BugController(DataContext context)
        {
            this.Context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecretKey()
        {
            return "secret key";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var text = Context.Users.Find(-1);
            if (text == null)
            {
                return NotFound();
            }
            return Ok(text);
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            return Context.Users.Find(-1).ToString();
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("Bad request...");
        }
    }
}