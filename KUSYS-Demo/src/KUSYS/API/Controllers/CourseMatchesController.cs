using Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseMatchesController : ControllerBase
    {

        private readonly BaseDbContext _baseDbContext;

        public CourseMatchesController(BaseDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseMatch>>> GetCourseMatchs()
        {
            return await _baseDbContext.CourseMatches.ToListAsync();
        }

        [HttpGet("{id}")] // api/courseMatch/1
        public async Task<ActionResult<CourseMatch>> GetCourseMatch(int id)
        {
            return await _baseDbContext.CourseMatches.FindAsync(id);
        }
    }
}
