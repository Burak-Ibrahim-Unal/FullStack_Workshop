using Application.Features.Vehicles.Commands;
using Application.Features.Vehicles.Dtos;
using Application.Features.Vehicles.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : BaseController
    {

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetVehicleByIdQuery getModelByIdQuery)
        {
            var result = await Mediator.Send(getModelByIdQuery);
            return Ok(result);
        }


        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetVehicleListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);

            //v2
            //GetVehicleListQuery getVehicleListQuery = new() { PageRequest = pageRequest };
            //var result = await Mediator.Send(getVehicleListQuery); // assign "GetVehicleListQuery getVehicleListQuery" a parameter
            //return Ok(result);
        }



        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateVehicleCommand createVehicleCommand)
        {
            var result = await Mediator.Send(createVehicleCommand);
            return Created("", result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteVehicleCommand deleteModelCommand)
        {

            var result = await Mediator.Send(deleteModelCommand);
            return Ok(result);
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateVehicleCommand updateModelCommand)
        {

            var result = await Mediator.Send(updateModelCommand);
            return Ok(result);
        }

        
    }
}