using Application.Features.IndividualCustomers.Commands;
using Application.Features.IndividualCustomers.Models;
using Application.Features.IndividualCustomers.Queries;
using Core.Application.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualCustomersController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetIndividualCustomerByIdQuery getIndividualCustomerByIdQuery)
    {
        IndividualCustomer result = await Mediator.Send(getIndividualCustomerByIdQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetIndividualCustomerListQuery getListIndividualCustomerQuery = new() { PageRequest = pageRequest };
        IndividualCustomerListModel result = await Mediator.Send(getListIndividualCustomerQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateIndividualCustomerCommand createIndividualCustomerCommand)
    {
        var result = await Mediator.Send(createIndividualCustomerCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateIndividualCustomerCommand updateIndividualCustomerCommand)
    {
        var result = await Mediator.Send(updateIndividualCustomerCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteIndividualCustomerCommand deleteIndividualCustomerCommand)
    {
        var result = await Mediator.Send(deleteIndividualCustomerCommand);
        return Ok(result);
    }
}