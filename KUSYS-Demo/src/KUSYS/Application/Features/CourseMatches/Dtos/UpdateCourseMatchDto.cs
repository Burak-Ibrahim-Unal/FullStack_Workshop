using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CourseMatches.Dtos
{
    public class UpdateCourseMatchDto
    {
        public int Id { get; set; }
        public string CourseId { get; set; }
        public string StrudentId { get; set; }
    }
}
