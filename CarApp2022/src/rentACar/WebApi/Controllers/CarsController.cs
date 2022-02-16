using Application.Features.Cars.Commands;
using Application.Features.Cars.Dtos;
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

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCarListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);

            //v2
            //GetCarListQuery getCarListQuery = new() { PageRequest = pageRequest };
            //var result = await Mediator.Send(getCarListQuery);
            //return Ok(result);
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


        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCarCommand updateModelCommand)
        {

            var result = await Mediator.Send(updateModelCommand);
            return Ok(result);
        }

        [HttpPut("getcarsbyavailable")]
        public async Task<IActionResult> GetCarsByAvailable([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCarListByAvaiableQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("getcarsbynotavailable")]
        public async Task<IActionResult> GetCarsByNotAvailable([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCarListByNotAvaiableQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("getcarsbynotundermaintenance")]
        public async Task<IActionResult> GetCarsByUnderMaintenance([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCarListByUnderMaintenanceQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("getcarsundermaintenance")]
        public async Task<IActionResult> GetCarsByNotUnderMaintenance([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCarListByNotUnderMaintenanceQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getcarsrentables")]
        public async Task<IActionResult> GetCarsByRentables([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCarListByRentableQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getcarsnotrentables")]
        public async Task<IActionResult> GetCarsByNotRentables([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCarListByNotAvaiableQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getcarsbycity")]
        public async Task<IActionResult> GetCarsByCity([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCarListByCityQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

    }
}