using Application.Features.Courses.Dtos;
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
    public interface ICourseRepository : IAsyncRepository<Course>, ISyncRepository<Course>
    {
        Task<CourseDto> GetCourseById(int id, CancellationToken cancellationToken = default);
        Task<IPaginate<CourseListDto>> GetAllCourses(int index = 0, int size = 10, CancellationToken cancellationToken = default);
    }
}
