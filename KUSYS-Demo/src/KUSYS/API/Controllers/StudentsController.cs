using Application.Features.Students.Commands;
using Application.Features.Students.Queries;
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
    public class StudentsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateStudentCommand createStudentCommand)
        {
            var result = await Mediator.Send(createStudentCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetStudentListQuery getStudentListQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getStudentListQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetStudentByIdQuery getStudentByIdQuery)
        {
            var result = await Mediator.Send(getStudentByIdQuery);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStudentCommand uptadeStudentCommand)
        {
            var result = await Mediator.Send(uptadeStudentCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteStudentCommand deleteStudentCommand)
        {
            var result = await Mediator.Send(deleteStudentCommand);
            return Ok(result);
        }
    }
}

