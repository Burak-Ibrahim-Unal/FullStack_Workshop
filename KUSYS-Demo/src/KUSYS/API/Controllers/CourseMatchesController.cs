using Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<CourseMatch>> GetCourseMatchs()
        {
            var courseMatches = _baseDbContext.CourseMatches.ToList();

            return Ok(courseMatches);
        }

        [HttpGet("{id}")] // api/courseMatch/1
        public ActionResult<CourseMatch> GetCourseMatch(int id)
        {
            return _baseDbContext.CourseMatches.Find(id);
        }
    }
}
