using Application.Features.CourseMatches.Dtos;
using Application.Features.CourseMatches.Rules;
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

namespace Application.Features.CourseMatches.Commands
{
    public class CreateCourseMatchCommand : IRequest<CreateCourseMatchDto>, ILoggableRequest
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }


        public class CreateCourseMatchCommandHandler : IRequestHandler<CreateCourseMatchCommand, CreateCourseMatchDto>
        {
            private readonly ICourseMatchRepository _courseMatchRepository;
            private readonly IMapper _mapper;
            private readonly CourseMatchBusinessRules _courseMatchBusinessRules;
            private readonly ICacheService _cacheService;
            //private readonly IMailService _mailService;


            public CreateCourseMatchCommandHandler(ICourseMatchRepository courseMatchRepository,
                IMapper mapper,
                CourseMatchBusinessRules courseMatchBusinessRules,
                ICacheService cacheService
                /*IMailService mailService*/)
            {
                _courseMatchRepository = courseMatchRepository;
                _mapper = mapper;
                _courseMatchBusinessRules = courseMatchBusinessRules;
                _cacheService = cacheService;
                //_mailService = mailService;
            }


            public async Task<CreateCourseMatchDto> Handle(CreateCourseMatchCommand request, CancellationToken cancellationToken)
            {
                await _courseMatchBusinessRules.CheckCourseMatchById(request.StudentId, request.CourseId);

                CourseMatch mappedCourseMatch = _mapper.Map<CourseMatch>(request);

                CourseMatch createdCourseMatch = await _courseMatchRepository.AddAsync(mappedCourseMatch);

                _cacheService.Remove("coursematches-list");

                #region send mail 
                //var mail = new Mail
                //{
                //    Subject = "Bootcamp - Add New CourseMatch",
                //    ToFullName = "Burak İbrahim Ünal",
                //    ToEmail = "burakibrahim@gmail.com",
                //    HtmlBody = "aaaaaaaaaaaaaaaaaaaaaaaaaaa bbbbbbbbbbbbbbbbbbbbbbbbb"

                //};
                //_mailService.SendEmail(mail); 
                #endregion

                CreateCourseMatchDto courseMatchDtoToReturn = _mapper.Map<CreateCourseMatchDto>(createdCourseMatch);

                return courseMatchDtoToReturn;
            }
        }
    }
}
