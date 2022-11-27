using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CourseMatches.Dtos
{
    public class CourseMatchListDto
    {
        public int Id { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }


    }
}
