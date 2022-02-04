﻿using Application.Features.Colors.Commands;
using Application.Features.Colors.Queries.GetByIdColor;
using Application.Features.Colors.Queries.GetColorList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : BaseController
    {


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetColorListQuery();
            query.pageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetColorByIdQuery getColorByIdQuery)
        {
            var result = await Mediator.Send(getColorByIdQuery);
            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateColorCommand createColorCommand)
        {
            var result = await Mediator.Send(createColorCommand);
            return Created("", result);

        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteColorCommand deleteColorCommand)
        {

            var result = await Mediator.Send(deleteColorCommand);
            return Ok(result);
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateColorCommand updateColorCommand)
        {

            var result = await Mediator.Send(updateColorCommand);
            return Ok(result);
        }
    }
}
