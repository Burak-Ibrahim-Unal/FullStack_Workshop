using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        [HttpGet("not-found")]
        public ActionResult GetNotFound()
        {
            return NotFound();
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ProblemDetails { Title = "Bad Request..." });
        }

        [HttpGet("unauthorized")]
        public ActionResult GetUnauthorized()
        {
            return Unauthorized();
        }


        [HttpGet("validation-error")]
        public ActionResult GetValidationError()
        {
            ModelState.AddModelError("Problem1 occured", "First Error...");
            ModelState.AddModelError("Problem2 occured", "Second Error...");
            return ValidationProblem();
        }

        [HttpGet("Server-error")]
        public ActionResult GetServerError()
        {
            throw new Exception("Server error...");
        }
    }
}
