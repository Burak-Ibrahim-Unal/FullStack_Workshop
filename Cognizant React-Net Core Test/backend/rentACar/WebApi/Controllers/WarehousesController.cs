using Application.Features.Warehouses.Commands;
using Application.Features.Warehouses.Dtos;
using Application.Features.Warehouses.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : BaseController
    {

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetWarehouseByIdQuery getModelByIdQuery)
        {
            var result = await Mediator.Send(getModelByIdQuery);
            return Ok(result);
        }


        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetWarehouseListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);

            //v2
            //GetWarehouseListQuery getWarehouseListQuery = new() { PageRequest = pageRequest };
            //var result = await Mediator.Send(getWarehouseListQuery); // assign "GetWarehouseListQuery getWarehouseListQuery" a parameter
            //return Ok(result);
        }



        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateWarehouseCommand createWarehouseCommand)
        {
            var result = await Mediator.Send(createWarehouseCommand);
            return Created("", result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteWarehouseCommand deleteModelCommand)
        {

            var result = await Mediator.Send(deleteModelCommand);
            return Ok(result);
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateWarehouseCommand updateModelCommand)
        {

            var result = await Mediator.Send(updateModelCommand);
            return Ok(result);
        }

        
    }
}