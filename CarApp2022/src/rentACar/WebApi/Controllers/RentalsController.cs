using Application.Features.Rentals.Commands;
using Application.Features.Rentals.Models;
using Application.Features.Rentals.Queries;
using Core.Application.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalsController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdRentalQuery getByIdRentalQuery)
    {
        var result = await Mediator.Send(getByIdRentalQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var query = new GetListRentalQuery();
        query.PageRequest = pageRequest;
        var result = await Mediator.Send(query);
        return Ok(result);

        //v2
        //GetListRentalQuery getListRentalQuery = new() { PageRequest = pageRequest };
        //var result = await Mediator.Send(getListRentalQuery);
        //return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRentalCommand createRentalCommand)
    {
        var result = await Mediator.Send(createRentalCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRentalCommand updateRentalCommand)
    {
        var result = await Mediator.Send(updateRentalCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteRentalCommand deleteRentalCommand)
    {
        var result = await Mediator.Send(deleteRentalCommand);
        return Ok(result);
    }
}