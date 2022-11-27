using Application.Features.CourseMatches.Dtos;
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
    public interface ICourseMatchRepository : IAsyncRepository<CourseMatch>, ISyncRepository<CourseMatch>
    {
        Task<CourseMatchDto> GetCourseMatchById(int id, CancellationToken cancellationToken = default);
        Task<IPaginate<CourseMatchListDto>> GetAllCourseMatches(int index = 0, int size = 10, CancellationToken cancellationToken = default);
    }
}
