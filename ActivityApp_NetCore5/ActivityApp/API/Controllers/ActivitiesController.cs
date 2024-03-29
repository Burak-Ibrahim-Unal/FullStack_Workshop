using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers;
using Application.Features.Activities.Commands;
using Application.Features.Activities.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace API
{
    // [AllowAnonymous] // we add AuthorizeFilter for every endpoints...
    public class ActivitiesController : BaseApiController
    {

        // handle result is common method like mediatr...It located in baseapicontroller...And referenced from Core layer...

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            return HandleResult(await Mediator.Send(new GetActivityListQuery.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetActivityByIdQuery.Query { Id = id }));
        }


        // if we dont return anything and if we just need  http responses(return,ok,bad request,not found), we ca use use IActionResult
        [HttpPost()]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return HandleResult(await Mediator.Send(new CreateActivityCommand.Command { Activity = activity }));
        }


        [Authorize(Policy = "IsActivityHost")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return HandleResult(await Mediator.Send(new EditActivityCommand.Command { Activity = activity }));
        }


        [Authorize(Policy = "IsActivityHost")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteActivityCommand.Command { Id = id }));
        }

        [HttpPost("{id}/attend")]
        public async Task<IActionResult> Attend(Guid id)
        {
            return HandleResult(await Mediator.Send(new UpdateAttendance.UpdateAttendanceCommand { Id = id }));
        }

    }
}