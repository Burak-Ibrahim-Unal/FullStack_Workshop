using Application.Features.Locations.Commands;
using Application.Features.Locations.Dtos;
using Application.Features.Locations.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : BaseController
    {

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetLocationByIdQuery getModelByIdQuery)
        {
            var result = await Mediator.Send(getModelByIdQuery);
            return Ok(result);
        }


        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetLocationListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);

            //v2
            //GetLocationListQuery getLocationListQuery = new() { PageRequest = pageRequest };
            //var result = await Mediator.Send(getLocationListQuery); // assign "GetLocationListQuery getLocationListQuery" a parameter
            //return Ok(result);
        }



        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateLocationCommand createLocationCommand)
        {
            var result = await Mediator.Send(createLocationCommand);
            return Created("", result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteLocationCommand deleteModelCommand)
        {

            var result = await Mediator.Send(deleteModelCommand);
            return Ok(result);
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateLocationCommand updateModelCommand)
        {

            var result = await Mediator.Send(updateModelCommand);
            return Ok(result);
        }

        
    }
}