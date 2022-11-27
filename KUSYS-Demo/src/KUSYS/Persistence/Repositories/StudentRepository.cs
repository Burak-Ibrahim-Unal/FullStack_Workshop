using Application.Features.Students.Dtos;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entites;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class StudentRepository : EfRepositoryBase<Student, BaseDbContext>, IStudentRepository
    {

        public StudentRepository(BaseDbContext context) : base(context)
        {

        }

        public Task<StudentDto?> GetStudentById(int id, CancellationToken cancellationToken = default)
        {
            var result = from student in Context.Students
                         where student.Id == id

                         select new StudentDto
                         {
                             Id = student.Id,
                             FirstName = student.FirstName,
                             LastName = student.LastName,
                             BirthDate = student.BirthDate,
                         };

            return Task.FromResult(result.FirstOrDefault());
        }

        public async Task<IPaginate<StudentListDto>> GetAllStudents(int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            var result = from student in Context.Students

                         select new StudentListDto
                         {
                             Id = student.Id,
                             FirstName = student.FirstName,
                             LastName = student.LastName,
                             BirthDate = student.BirthDate,
                         };

            return await result.ToPaginateAsync(index, size, 0, cancellationToken);
        }
    }
}
