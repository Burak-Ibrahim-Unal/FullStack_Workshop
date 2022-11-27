using Application.Features.Students.Dtos;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities;
using Domain.Entites;
using MediatR;

namespace Application.Features.Students.Commands;

public class DeleteStudentCommand : IRequest<DeleteStudentDto> 
{
    public int Id { get; set; }

    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, DeleteStudentDto>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper, ICacheService cacheService)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<DeleteStudentDto> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            Student studentToDelete = await _studentRepository.GetAsync(x => x.Id == request.Id);

            if (studentToDelete == null) throw new BusinessException(Messages.StudentDoesNotExist);

            Student deletedStudent = await _studentRepository.DeleteAsync(studentToDelete);
            _cacheService.Remove("students-list");

            DeleteStudentDto deletedStudentDto = _mapper.Map<DeleteStudentDto>(deletedStudent);
            return deletedStudentDto;
        }
    }
}

