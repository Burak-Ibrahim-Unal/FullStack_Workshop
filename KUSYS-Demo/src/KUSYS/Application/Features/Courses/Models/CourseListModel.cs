using Application.Features.Courses.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Models
{
    public class CourseListModel : BasePageableModel
    {
        public IList<CourseListDto> Items { get; set; }


    }
}
