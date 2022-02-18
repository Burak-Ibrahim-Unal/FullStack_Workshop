using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace API
{
    public class ActivitiesController : BaseApiController
    {
        public readonly DataContext _dataContext;
        public ActivitiesController(DataContext dataContext)
        {
            _dataContext = dataContext;

        }


        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _dataContext.Activities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityById(Guid id)
        {
            return await _dataContext.Activities.FindAsync(id);
        }



    }
}