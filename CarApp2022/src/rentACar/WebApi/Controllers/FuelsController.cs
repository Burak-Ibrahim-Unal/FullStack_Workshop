using Application.Features.Fuels.Commands;
using Application.Features.Fuels.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : BaseController
    {


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetFuelListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);

            //v2
            //GetFuelListQuery getFuelListQuery = new() { PageRequest = pageRequest };
            //var result = await Mediator.Send(getFuelListQuery);
            //return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetFuelByIdQuery getByIdFuelQuery)
        {
            var result = await Mediator.Send(getByIdFuelQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFuelCommand createFuelCommand)
        {
            var result = await Mediator.Send(createFuelCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFuelCommand uptadeFuelCommand)
        {
            var result = await Mediator.Send(uptadeFuelCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteFuelCommand deleteFuelCommand)
        {
            var result = await Mediator.Send(deleteFuelCommand);
            return Ok(result);
        }
    }
}