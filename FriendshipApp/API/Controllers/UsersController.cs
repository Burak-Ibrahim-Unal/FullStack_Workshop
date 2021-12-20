using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;
using API.DTOs;
using AutoMapper;
using System.Collections;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _userRepository.GetMembersAsync();

            return Ok(users);
        }

        [HttpGet("{username}")] // api/users/1
        public async Task<ActionResult<MemberDto>> GetUserByName(string username)
        {
            return await _userRepository.GetMemberByUsernameAsync(username);
        }

        [HttpGet("{id:int}")] // api/users/1
        public async Task<ActionResult<MemberDto>> GetUserById(int id)
        {
            return await _userRepository.GetMemberByIdAsync(id);

        }


        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userRepository.GetUserByNameAsync(username);


            _mapper.Map(memberUpdateDto, user);
            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user...");


        }


    }
}