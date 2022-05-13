using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers;
using Application.Photos;
using Application.Profiles;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace API
{
    // [AllowAnonymous] // we add AuthorizeFilter for every endpoints...
    public class ProfilesController : BaseApiController
    {

        // handle result is common method like mediatr...It located in baseapicontroller...And referenced from Core layer..


        [HttpGet("username")]
        public async Task<IActionResult> GetProfile(string username)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Username = username }));
        }


    }
}