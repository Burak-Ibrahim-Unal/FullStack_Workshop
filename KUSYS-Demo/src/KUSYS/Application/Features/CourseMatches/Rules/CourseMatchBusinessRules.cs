using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Utilities;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CourseMatches.Rules
{
    public class CourseMatchBusinessRules
    {
        ICourseMatchRepository _courseRepository;

        public CourseMatchBusinessRules(ICourseMatchRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        //Gerkhin 
        //cross cutting concern
        public async Task CheckCourseMatchById(int studentId, int courseId)
        {
            IPaginate<CourseMatch> result = await _courseRepository.GetListAsync(c => c.StudentId == studentId && c.CourseId == courseId);

            if (result.Items.Any()) throw new BusinessException(Messages.CourseMatchExists);
        }


        public async Task CheckCourseMatchById(int id)
        {
            CourseMatch result = await _courseRepository.GetAsync(course => course.Id == id);

            if (result == null) throw new BusinessException(Messages.CourseMatchDoesNotExist);
        }


    }
}
