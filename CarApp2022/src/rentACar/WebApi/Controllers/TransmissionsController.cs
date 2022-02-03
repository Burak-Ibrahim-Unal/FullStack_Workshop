using Application.Features.Transmissions.Commands.CreateTransmission;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateTransmissionCommand createTransmissionCommand)
        {
            var result = await Mediator.Send(createTransmissionCommand);
            return Created("", result);
        }
    }
}