using Application.Features.Cars.Commands.CreateCar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCarCommand createCarCommand)
        {
            var result = await Mediator.Send(createCarCommand);
            return Created("", result);
        }
    }
}