using Application.Features.FindeksCreditRates.Commands;
using Application.Features.FindeksCreditRates.Models;
using Application.Features.FindeksCreditRates.Queries;
using Core.Application.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FindeksCreditRatesController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetFindeksCreditRateByIdQuery getFindeksCreditRateByIdQuery)
    {
        var result = await Mediator.Send(getFindeksCreditRateByIdQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var query = new GetFindeksCreditRateListQuery();
        query.PageRequest = pageRequest;
        var result = await Mediator.Send(query);
        return Ok(result);

        //v2
        //GetFindeksCreditRateListQuery getFindeksCreditRateListQuery = new() { PageRequest = pageRequest };
        //var result = await Mediator.Send(getFindeksCreditRateListQuery);
        //return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFindeksCreditRateCommand createFindeksCreditRateCommand)
    {
        FindeksCreditRate result = await Mediator.Send(createFindeksCreditRateCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFindeksCreditRateCommand updateFindeksCreditRateCommand)
    {
        var result = await Mediator.Send(updateFindeksCreditRateCommand);
        return Ok(result);
    }

    //[HttpPut("FromService")]
    //public async Task<IActionResult> UpdateFromService(
    //    [FromBody] UpdateFindeksCreditRateFromServiceCommand findeksCreditRateFromServiceCommand)
    //{
    //    var result = await Mediator.Send(findeksCreditRateFromServiceCommand);
    //    return Ok(result);
    //}

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteFindeksCreditRateCommand deleteFindeksCreditRateCommand)
    {
        var result = await Mediator.Send(deleteFindeksCreditRateCommand);
        return Ok(result);
    }
}