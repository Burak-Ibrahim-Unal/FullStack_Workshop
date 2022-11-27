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

public class UpdateStudentCommand : IRequest<UpdateStudentDto>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, UpdateStudentDto>
    {
        private IStudentRepository _studentRepository;
        private IMapper _mapper;
        private StudentBusinessRules _studentBusinessRules;
        private ICacheService _cacheService;

        public UpdateStudentHandler(StudentBusinessRules studentBusinessRules, IStudentRepository studentRepository, IMapper mapper, ICacheService cacheService)
        {
            _studentBusinessRules = studentBusinessRules;
            _studentRepository = studentRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<UpdateStudentDto> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentToUpdate = await _studentRepository.GetAsync(x => x.Id == request.Id);

            if (studentToUpdate == null) throw new BusinessException(Messages.StudentDoesNotExist);

            studentToUpdate = _mapper.Map(request, studentToUpdate);
            Student updatedStudent = await _studentRepository.UpdateAsync(studentToUpdate);

            _cacheService.Remove("students-list");

            UpdateStudentDto studentToReturn = _mapper.Map<UpdateStudentDto>(updatedStudent);
            return studentToReturn;
        }
    }

}