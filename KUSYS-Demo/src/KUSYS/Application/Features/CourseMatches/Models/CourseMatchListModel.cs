using Application.Features.CourseMatches.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CourseMatches.Models
{
    public class CourseMatchListModel : BasePageableModel
    {
        public IList<CourseMatchListDto> Items { get; set; }


    }
}
