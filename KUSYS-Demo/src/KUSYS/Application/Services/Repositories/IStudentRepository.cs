using Application.Features.Students.Dtos;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface IStudentRepository : IAsyncRepository<Student>, ISyncRepository<Student>
    {
        Task<StudentDto> GetStudentById(int id, CancellationToken cancellationToken = default);
        Task<IPaginate<StudentListDto>> GetAllStudents(int index = 0, int size = 10, CancellationToken cancellationToken = default);
    }
}
