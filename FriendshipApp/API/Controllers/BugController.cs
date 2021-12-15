using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BugController : BaseApiController
    {
        private readonly DataContext _dataContext;
        public BugController(DataContext dataContext)
        {
            _dataContext = dataContext;

        }

        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "Secret Key";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var temp = _dataContext.Users.Find(-1);
            if (temp == null)
            {
                return NotFound();
            }
            return Ok(temp);
        }

        [HttpGet("server-error")]
        public ActionResult<string> GeServerError()
        {
             var temp = _dataContext.Users.Find(-1);
             return temp.ToString();
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("Bad Request...");
        }



    }
}