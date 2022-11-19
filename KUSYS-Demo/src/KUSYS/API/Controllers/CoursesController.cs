using Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<Course>> GetCourses()
        {
            var courses = _baseDbContext.Courses.ToList();

            return Ok(courses);
        }

        [HttpGet("{id}")] // api/course/1
        public ActionResult<Course> GetCourse(int id)
        {
            return _baseDbContext.Courses.Find(id);
        }
    }
}
