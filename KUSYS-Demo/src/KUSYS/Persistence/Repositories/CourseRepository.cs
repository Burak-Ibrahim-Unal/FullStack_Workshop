using Application.Features.Courses.Dtos;
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
    public class CourseRepository : EfRepositoryBase<Course, BaseDbContext>, ICourseRepository
    {

        public CourseRepository(BaseDbContext context) : base(context)
        {

        }

        public Task<CourseDto?> GetCourseById(int id, CancellationToken cancellationToken = default)
        {
            var result = from course in Context.Courses
                         where course.Id == id

                         select new CourseDto
                         {
                             Id = course.Id,
                             CourseName = course.CourseName,
                             CourseId = course.CourseId,
                         };

            return Task.FromResult(result.FirstOrDefault());
        }

        public async Task<IPaginate<CourseListDto>> GetAllCourses(int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            var result = from course in Context.Courses

                         select new CourseListDto
                         {
                             Id = course.Id,
                             CourseId= course.CourseId,
                             CourseName = course.CourseName,
                         };

            return await result.ToPaginateAsync(index, size, 0, cancellationToken);
        }
    }
}
