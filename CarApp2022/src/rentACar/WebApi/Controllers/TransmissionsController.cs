using Application.Features.Transmissions.Commands;
using Application.Features.Transmissions.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionsController : BaseController
    {


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetTransmissionListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);

            //v2
            //GetTransmissionListQuery getTransmissionListQuery = new() { PageRequest = pageRequest };
            //var result = await Mediator.Send(getTransmissionListQuery);
            //return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetTransmissionByIdQuery getByIdTransmissionQuery)
        {
            var result = await Mediator.Send(getByIdTransmissionQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTransmissionCommand createTransmissionCommand)
        {
            var result = await Mediator.Send(createTransmissionCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTransmissionCommand uptadeTransmissionCommand)
        {
            var result = await Mediator.Send(uptadeTransmissionCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTransmissionCommand deleteTransmissionCommand)
        {
            var result = await Mediator.Send(deleteTransmissionCommand);
            return Ok(result);
        }
    }
}
