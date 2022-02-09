using Application.Features.CorporateCustomers.Commands;
using Application.Features.CorporateCustomers.Models;
using Application.Features.CorporateCustomers.Queries;
using Core.Application.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CorporateCustomersController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetCorporateCustomerByIdQuery getCorporateCustomerByIdQuery)
    { 
        var result = await Mediator.Send(getCorporateCustomerByIdQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var query = new GetCorporateCustomerListQuery();
        query.PageRequest = pageRequest;
        var result = await Mediator.Send(query);
        return Ok(result);

        //V2
        //GetCorporateCustomerListQuery getCorporateCustomerByIdQuery = new() { PageRequest = pageRequest };
        //CorporateCustomerListModel result = await Mediator.Send(getCorporateCustomerByIdQuery);
        //return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCorporateCustomerCommand createCorporateCustomerCommand)
    {
        var result = await Mediator.Send(createCorporateCustomerCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCorporateCustomerCommand updateCorporateCustomerCommand)
    {
        var result = await Mediator.Send(updateCorporateCustomerCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCorporateCustomerCommand deleteCorporateCustomerCommand)
    {
        var result = await Mediator.Send(deleteCorporateCustomerCommand);
        return Ok(result);
    }
}