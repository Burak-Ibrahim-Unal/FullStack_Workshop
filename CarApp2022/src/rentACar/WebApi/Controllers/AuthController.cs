using Application.Features.Users.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("login")]
        public async ActionResult Login(LoginUserCommand loginUserCommand)
        {
            var userToLogin = await Mediator.Send(loginUserCommand);

            if (userToLogin.IsLoginSuccess)
            {

            }

        }


    }
}
