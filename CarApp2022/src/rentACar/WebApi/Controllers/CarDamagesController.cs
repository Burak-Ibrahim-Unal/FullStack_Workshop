using Application.Features.CarDamages.Commands;
using Application.Features.CarDamages.Dtos;
using Application.Features.CarDamages.Models;
using Application.Features.CarDamages.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarDamagesController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetCarDamageByIdQuery getCarDamageByIdQuery)
    {
        CarDamageDto result = await Mediator.Send(getCarDamageByIdQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetCarDamageListQuery getCarDamageListQuery = new() { PageRequest = pageRequest };
        CarDamageListModel result = await Mediator.Send(getCarDamageListQuery);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCarDamageCommand createCarDamageCommand)
    {
        CreateCarDamageDto result = await Mediator.Send(createCarDamageCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCarDamageCommand updateCarDamageCommand)
    {
        UpdateCarDamageDto result = await Mediator.Send(updateCarDamageCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCarDamageCommand deleteCarDamageCommand)
    {
        DeleteCarDamageDto result = await Mediator.Send(deleteCarDamageCommand);
        return Ok(result);
    }
}