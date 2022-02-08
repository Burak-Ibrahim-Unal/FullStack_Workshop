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
        CorporateCustomer result = await Mediator.Send(getCorporateCustomerByIdQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetCorporateCustomerListQuery getCorporateCustomerByIdQuery = new() { PageRequest = pageRequest };
        CorporateCustomerListModel result = await Mediator.Send(getCorporateCustomerByIdQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCorporateCustomerCommand createCorporateCustomerCommand)
    {
        CorporateCustomer result = await Mediator.Send(createCorporateCustomerCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCorporateCustomerCommand updateCorporateCustomerCommand)
    {
        CorporateCustomer result = await Mediator.Send(updateCorporateCustomerCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCorporateCustomerCommand deleteCorporateCustomerCommand)
    {
        CorporateCustomer result = await Mediator.Send(deleteCorporateCustomerCommand);
        return Ok(result);
    }
}