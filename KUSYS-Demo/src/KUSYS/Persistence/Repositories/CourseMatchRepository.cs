using Application.Features.CourseMatches.Dtos;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entites;
using Nest;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CourseMatchRepository : EfRepositoryBase<CourseMatch, BaseDbContext>, ICourseMatchRepository
    {

        public CourseMatchRepository(BaseDbContext context) : base(context)
        {

        }

        public Task<CourseMatchDto?> GetCourseMatchById(int id, CancellationToken cancellationToken = default)
        {
            var result = from courseMatch in Context.CourseMatches
                         join course in Context.Courses
                         on courseMatch.CourseId equals course.Id
                         join student in Context.Students
                         on courseMatch.StudentId equals student.Id
                         where courseMatch.Id == id

                         select new CourseMatchDto
                         {
                             Id = courseMatch.Id,
                             CourseId = course.CourseId,
                             CourseName = course.CourseName,
                             StudentFirstName = student.FirstName,
                             StudentLastName = student.LastName,


                         };

            return Task.FromResult(result.FirstOrDefault());
        }

        public async Task<IPaginate<CourseMatchListDto>> GetAllCourseMatches(int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            var result = from courseMatch in Context.CourseMatches
                         join course in Context.Courses
                         on courseMatch.CourseId equals course.Id
                         join student in Context.Students
                         on courseMatch.StudentId equals student.Id

                         select new CourseMatchListDto
                         {
                             Id = courseMatch.Id,
                             CourseId = course.CourseId,
                             CourseName = course.CourseName,
                             StudentFirstName = student.FirstName,
                             StudentLastName = student.LastName,
                         };

            return await result.ToPaginateAsync(index, size, 0, cancellationToken);
        }
    }
}
