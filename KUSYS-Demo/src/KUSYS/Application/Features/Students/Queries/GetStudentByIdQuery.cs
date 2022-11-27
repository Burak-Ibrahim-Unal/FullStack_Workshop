using Application.Features.Students.Dtos;
using Application.Features.Students.Models;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Students.Queries;

public class GetStudentByIdQuery : IRequest<StudentDto>
{
    public int Id { get; set; }

    public class GetByIdStudentResponseHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly StudentBusinessRules _studentBusinessRules;
        private readonly IMapper _mapper;


        public GetByIdStudentResponseHandler(IStudentRepository studentRepository, StudentBusinessRules studentBusinessRules, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _studentBusinessRules = studentBusinessRules;
            _mapper = mapper;
        }


        public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            await _studentBusinessRules.CheckStudentById(request.Id);

            Student student = await _studentRepository.GetAsync(b => b.Id == request.Id);
            StudentDto studentDtoToReturn = _mapper.Map<StudentDto>(student);
            return studentDtoToReturn;
        }
    }
}