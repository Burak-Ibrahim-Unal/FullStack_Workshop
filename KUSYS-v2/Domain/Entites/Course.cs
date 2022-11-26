using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Course : Entity
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
