using Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        private readonly BaseDbContext _baseDbContext;

        public CoursesController(BaseDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetCourses()
        {
            return await _baseDbContext.Courses.ToListAsync();

        }

        [HttpGet("{id}")] // api/course/1
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            return await _baseDbContext.Courses.FindAsync(id);
        }
    }
}
