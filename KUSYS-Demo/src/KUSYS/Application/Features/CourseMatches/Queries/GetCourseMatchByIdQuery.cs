using Application.Features.CourseMatches.Dtos;
using Application.Features.CourseMatches.Models;
using Application.Features.CourseMatches.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.CourseMatches.Queries;

public class GetCourseMatchByIdQuery : IRequest<CourseMatchDto>
{
    public int Id { get; set; }

    public class GetByIdCourseMatchResponseHandler : IRequestHandler<GetCourseMatchByIdQuery, CourseMatchDto>
    {
        private readonly ICourseMatchRepository _courseRepository;
        private readonly CourseMatchBusinessRules _courseBusinessRules;
        private readonly IMapper _mapper;


        public GetByIdCourseMatchResponseHandler(ICourseMatchRepository courseRepository, CourseMatchBusinessRules courseBusinessRules, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _courseBusinessRules = courseBusinessRules;
            _mapper = mapper;
        }


        public async Task<CourseMatchDto> Handle(GetCourseMatchByIdQuery request, CancellationToken cancellationToken)
        {
            await _courseBusinessRules.CheckCourseMatchById(request.Id);

            CourseMatch course = await _courseRepository.GetAsync(b => b.Id == request.Id);
            CourseMatchDto courseDtoToReturn = _mapper.Map<CourseMatchDto>(course);
            return courseDtoToReturn;
        }
    }
}