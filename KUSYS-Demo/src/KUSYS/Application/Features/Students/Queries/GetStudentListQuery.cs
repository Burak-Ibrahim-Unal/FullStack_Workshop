using Application.Features.Students.Models;
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

namespace Application.Features.Students.Queries
{
    public class GetStudentListQuery : IRequest<StudentListModel>, ICachableRequest
    {
        public PageRequest? PageRequest { get; set; }

     
        public string CacheKey => "students-list";

        public bool BypassCache { get; set; }

        public TimeSpan? SlidingExpiration { get; set; } 


        public class GetStudentListQueryHandler : IRequestHandler<GetStudentListQuery, StudentListModel>
        {
            IStudentRepository _studentRepository;
            IMapper _mapper;

            public GetStudentListQueryHandler(IStudentRepository studentRepository, IMapper mapper)
            {
                _studentRepository = studentRepository;
                _mapper = mapper;
            }

            public async Task<StudentListModel> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Student> students = await _studentRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                StudentListModel mappedStudentsList = _mapper.Map<StudentListModel>(students);

                return mappedStudentsList;
            }

        }
    }
}