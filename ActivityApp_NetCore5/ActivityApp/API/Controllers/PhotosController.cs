using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers;
using Application.Photos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace API
{
    // [AllowAnonymous] // we add AuthorizeFilter for every endpoints...
    public class PhotosController : BaseApiController
    {

        // handle result is common method like mediatr...It located in baseapicontroller...And referenced from Core layer..


        [HttpPost()]
        public async Task<IActionResult> AddPhoto([FromForm] AddPhoto.Command command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(string id)
        {
            return HandleResult(await Mediator.Send(new DeletePhoto.Command { Id = id }));
        }


    }
}