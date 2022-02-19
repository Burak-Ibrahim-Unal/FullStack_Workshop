using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers;
using Application.Features.Activities.Commands;
using Application.Features.Activities.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace API
{
    public class ActivitiesController : BaseApiController
    {


        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new GetActivityListQuery.Query());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityById(Guid id)
        {
            return await Mediator.Send(new GetActivityByIdQuery.Query { Id = id });
        }


        // if we dont return anything and if we just need  http responses(return,ok,bad request,not found), we ca use use IActionResult
        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await Mediator.Send(new CreateActivityCommand.Command { Activity = activity }));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteActivityCommand.Command { Id = id }));
        }


    }
}