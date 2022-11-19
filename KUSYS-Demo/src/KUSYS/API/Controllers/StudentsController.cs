using Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            return await _baseDbContext.Students.ToListAsync();

        }

        [HttpGet("{id}")] // api/student/1
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            return await _baseDbContext.Students.FindAsync(id);
        }
    }
}
