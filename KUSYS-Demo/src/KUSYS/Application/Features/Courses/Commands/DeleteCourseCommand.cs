using Application.Features.Courses.Dtos;
using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entites;
using MediatR;

namespace Application.Features.Courses.Commands;

public class DeleteCourseCommand : IRequest<DeleteCourseDto> 
{
    public int Id { get; set; }

    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, DeleteCourseDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public DeleteCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper, ICacheService cacheService)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<DeleteCourseDto> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            Course courseToDelete = await _courseRepository.GetAsync(x => x.Id == request.Id);

            if (courseToDelete == null) throw new BusinessException(Messages.CourseDoesNotExist);

            Course deletedCourse = await _courseRepository.DeleteAsync(courseToDelete);
            _cacheService.Remove("courses-list");

            DeleteCourseDto deletedCourseDto = _mapper.Map<DeleteCourseDto>(deletedCourse);
            return deletedCourseDto;
        }
    }
}

