using Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Contexts;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly BaseDbContext _baseDbContext;

        public StudentsController(BaseDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;
        }

        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            var students = _baseDbContext.Students.ToList();

            return Ok(students);
        }

        [HttpGet("{id}")] // api/student/1
        public ActionResult<Student> GetStudent(int id)
        {
            return _baseDbContext.Students.Find(id);
        }
    }
}
