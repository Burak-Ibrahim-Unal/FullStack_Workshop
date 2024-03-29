﻿using Application.Features.Customers.Commands;
using Application.Features.Customers.Models;
using Application.Features.Customers.Queries;
using Core.Application.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetCustomerByIdQuery getCustomerByIdQuery)
    {
        var result = await Mediator.Send(getCustomerByIdQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var query = new GetCustomerListQuery();
        query.PageRequest = pageRequest;
        var result = await Mediator.Send(query);
        return Ok(result);

        //v2
        //GetCustomerListQuery getCustomerListQuery = new() { PageRequest = pageRequest };
        //var result = await Mediator.Send(getCustomerListQuery);
        //return Ok(result);


    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerCommand createCustomerCommand)
    {
        var result = await Mediator.Send(createCustomerCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
    {
        var result = await Mediator.Send(updateCustomerCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommand deleteCustomerCommand)
    {
        var result = await Mediator.Send(deleteCustomerCommand);
        return Ok(result);
    }
}