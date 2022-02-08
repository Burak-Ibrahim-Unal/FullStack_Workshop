using Application.Features.Invoices.Commands;
using Application.Features.Invoices.Models;
using Application.Features.Invoices.Queries;
using Core.Application.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoicesController : BaseController
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] GetInvoiceByIdQuery request)
    {
        Invoice result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("ByDates")]
    public async Task<IActionResult> GetById([FromQuery] GetInvoiceListByDatesQuery request)
    {
        InvoiceListModel result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("ByCustomerId")]
    public async Task<IActionResult> GetById([FromQuery] GetInvoiceListByCustomerQuery request)
    {
        InvoiceListModel result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest request)
    {
        GetInvoiceListQuery getInvoiceListQuery = new() { PageRequest = request };
        InvoiceListModel result = await Mediator.Send(getInvoiceListQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateInvoiceCommand createInvoiceCommand)
    {
        var result = await Mediator.Send(createInvoiceCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateInvoiceCommand updateInvoiceCommand)
    {
        var result = await Mediator.Send(updateInvoiceCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteInvoiceCommand deleteInvoiceCommand)
    {
        var result = await Mediator.Send(deleteInvoiceCommand);
        return Ok(result);
    }
}