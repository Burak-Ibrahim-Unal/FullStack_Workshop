using Application.Features.Courses.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Queries
{
    public class GetCourseListQuery : IRequest<CourseListModel>, ICachableRequest
    {
        public PageRequest? PageRequest { get; set; }

     
        public string CacheKey => "courses-list";

        public bool BypassCache { get; set; }

        public TimeSpan? SlidingExpiration { get; set; } 


        public class GetCourseListQueryHandler : IRequestHandler<GetCourseListQuery, CourseListModel>
        {
            ICourseRepository _courseRepository;
            IMapper _mapper;

            public GetCourseListQueryHandler(ICourseRepository courseRepository, IMapper mapper)
            {
                _courseRepository = courseRepository;
                _mapper = mapper;
            }

            public async Task<CourseListModel> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Course> courses = await _courseRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                CourseListModel mappedCoursesList = _mapper.Map<CourseListModel>(courses);

                return mappedCoursesList;
            }

        }
    }
}