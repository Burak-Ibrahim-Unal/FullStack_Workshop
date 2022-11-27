using Application.Features.Courses.Commands;
using Application.Features.Courses.Queries;
using Core.Application.Requests;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using WebApi.Controllers;

namespace API.Controllers
{
    public class CoursesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCourseCommand createCourseCommand)
        {
            var result = await Mediator.Send(createCourseCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetCourseListQuery getCourseListQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getCourseListQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCourseByIdQuery getCourseByIdQuery)
        {
            var result = await Mediator.Send(getCourseByIdQuery);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCourseCommand uptadeCourseCommand)
        {
            var result = await Mediator.Send(uptadeCourseCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCourseCommand deleteCourseCommand)
        {
            var result = await Mediator.Send(deleteCourseCommand);
            return Ok(result);
        }
    }
}
