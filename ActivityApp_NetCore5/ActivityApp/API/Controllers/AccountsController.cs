using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers;
using API.DTOs;
using Application.Features.Activities.Commands;
using Application.Features.Activities.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace API
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountsController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;

        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
            {
                return new UserDto
                {
                    DisplayName = user.DisplayName,
                    Image = null,
                    Token = "token ...",
                    Username = user.UserName
                };
            }

            return Unauthorized();
        }
    }
}