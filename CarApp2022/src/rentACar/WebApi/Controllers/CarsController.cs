using Application.Features.Cars.Commands;
using Application.Features.Cars.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCarByIdQuery getModelByIdQuery)
        {
            var result = await Mediator.Send(getModelByIdQuery);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCarListQuery();
            query.pageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }





        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCarCommand createCarCommand)
        {
            var result = await Mediator.Send(createCarCommand);
            return Created("", result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCarCommand deleteModelCommand)
        {

            var result = await Mediator.Send(deleteModelCommand);
            return Ok(result);
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCarCommand updateModelCommand)
        {

            var result = await Mediator.Send(updateModelCommand);
            return Ok(result);
        }
    }
}