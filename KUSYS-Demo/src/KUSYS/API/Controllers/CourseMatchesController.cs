using Application.Features.CourseMatches.Commands;
using Application.Features.CourseMatches.Queries;
using Application.Features.CourseMatches.Commands;
using Application.Features.CourseMatches.Queries;
using Core.Application.Requests;
using Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class CourseMatchesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCourseMatchCommand createCourseMatchCommand)
        {
            var result = await Mediator.Send(createCourseMatchCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetCourseMatchListQuery getCourseMatchListQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getCourseMatchListQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCourseMatchByIdQuery getCourseMatchByIdQuery)
        {
            var result = await Mediator.Send(getCourseMatchByIdQuery);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCourseMatchCommand uptadeCourseMatchCommand)
        {
            var result = await Mediator.Send(uptadeCourseMatchCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCourseMatchCommand deleteCourseMatchCommand)
        {
            var result = await Mediator.Send(deleteCourseMatchCommand);
            return Ok(result);
        }
    }
}
