
using Application.Features.Colors.Commands.CreateColor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateColorCommand createColorCommand)
        {
            var result = await Mediator.Send(createColorCommand);
            return Created("", result);
        }
    }
}