using Application.Features.Students.Dtos;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Caching;
using Core.Mailing;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Commands
{
    public class CreateStudentCommand : IRequest<CreateStudentDto>, ILoggableRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }


        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreateStudentDto>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly IMapper _mapper;
            private readonly StudentBusinessRules _studentBusinessRules;
            private readonly ICacheService _cacheService;
            //private readonly IMailService _mailService;


            public CreateStudentCommandHandler(IStudentRepository studentRepository,
                IMapper mapper,
                StudentBusinessRules studentBusinessRules,
                ICacheService cacheService
                /*IMailService mailService*/)
            {
                _studentRepository = studentRepository;
                _mapper = mapper;
                _studentBusinessRules = studentBusinessRules;
                _cacheService = cacheService;
                //_mailService = mailService;
            }


            public async Task<CreateStudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
            {
                await _studentBusinessRules.CheckStudentByName(request.FirstName + " " + request.LastName);

                Student mappedStudent = _mapper.Map<Student>(request);

                Student createdStudent = await _studentRepository.AddAsync(mappedStudent);

                _cacheService.Remove("students-list");

                #region send mail 
                //var mail = new Mail
                //{
                //    Subject = "Bootcamp - Add New Student",
                //    ToFullName = "Burak İbrahim Ünal",
                //    ToEmail = "burakibrahim@gmail.com",
                //    HtmlBody = "aaaaaaaaaaaaaaaaaaaaaaaaaaa bbbbbbbbbbbbbbbbbbbbbbbbb"

                //};
                //_mailService.SendEmail(mail); 
                #endregion

                CreateStudentDto studentDtoToReturn = _mapper.Map<CreateStudentDto>(createdStudent);

                return studentDtoToReturn;
            }

        }

    }
}
