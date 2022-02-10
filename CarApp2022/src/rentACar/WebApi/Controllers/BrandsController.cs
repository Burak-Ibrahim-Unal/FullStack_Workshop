using Application.Features.Brands.Commands;
using Application.Features.Brands.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            var result = await Mediator.Send(createBrandCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetBrandListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);

            //v2
            //GetBrandListQuery getBrandListQuery = new() { PageRequest = pageRequest };
            //var result = await Mediator.Send(getBrandListQuery);
            //return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetBrandByIdQuery getBrandByIdQuery)
        {
            var result = await Mediator.Send(getBrandByIdQuery);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand uptadeBrandCommand)
        {
            var result = await Mediator.Send(uptadeBrandCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand deleteBrandCommand)
        {
            var result = await Mediator.Send(deleteBrandCommand);
            return Ok(result);
        }



    }
}