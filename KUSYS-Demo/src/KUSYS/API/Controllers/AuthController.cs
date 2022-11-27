using Application.Features.Users.Commands.LoginUser;
using Application.Features.Users.Commands.RegisterUser;
using Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginResult = await Mediator.Send(command);

            return Ok(loginResult);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var registerResult = await Mediator.Send(command);
            return Created("", registerResult);
        }       
        
        [HttpPost("roles")]
        public async Task<IActionResult> GetRole([FromQuery] GetUserOperationClaimsQuery getUserOperationClaimsQuery)
        {
            var result = await Mediator.Send(getUserOperationClaimsQuery);
            return Ok(result);
        }
    }
}
