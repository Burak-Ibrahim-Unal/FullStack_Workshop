using Application.Features.Courses.Dtos;
using Application.Features.Courses.Models;
using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Courses.Queries;

public class GetCourseByIdQuery : IRequest<CourseDto>
{
    public int Id { get; set; }

    public class GetByIdCourseResponseHandler : IRequestHandler<GetCourseByIdQuery, CourseDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly CourseBusinessRules _courseBusinessRules;
        private readonly IMapper _mapper;


        public GetByIdCourseResponseHandler(ICourseRepository courseRepository, CourseBusinessRules courseBusinessRules, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _courseBusinessRules = courseBusinessRules;
            _mapper = mapper;
        }


        public async Task<CourseDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            await _courseBusinessRules.CheckCourseById(request.Id);

            Course course = await _courseRepository.GetAsync(b => b.Id == request.Id);
            CourseDto courseDtoToReturn = _mapper.Map<CourseDto>(course);
            return courseDtoToReturn;
        }
    }
}