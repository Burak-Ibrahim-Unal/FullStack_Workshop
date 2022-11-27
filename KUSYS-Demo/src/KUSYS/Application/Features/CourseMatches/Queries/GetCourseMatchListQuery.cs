using Application.Features.CourseMatches.Dtos;
using Application.Features.CourseMatches.Models;
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

namespace Application.Features.CourseMatches.Queries
{
    public class GetCourseMatchListQuery : IRequest<CourseMatchListModel>, ICachableRequest
    {
        public PageRequest? PageRequest { get; set; }

     
        public string CacheKey => "coursematches-list";

        public bool BypassCache { get; set; }

        public TimeSpan? SlidingExpiration { get; set; } 


        public class GetCourseMatchListQueryHandler : IRequestHandler<GetCourseMatchListQuery, CourseMatchListModel>
        {
            ICourseMatchRepository _courseRepository;
            IMapper _mapper;

            public GetCourseMatchListQueryHandler(ICourseMatchRepository courseRepository, IMapper mapper)
            {
                _courseRepository = courseRepository;
                _mapper = mapper;
            }

            public async Task<CourseMatchListModel> Handle(GetCourseMatchListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<CourseMatchListDto> courses = await _courseRepository.GetAllCourseMatches(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                CourseMatchListModel mappedCourseMatchsList = _mapper.Map<CourseMatchListModel>(courses);

                return mappedCourseMatchsList;
            }

        }
    }
}