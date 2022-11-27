using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CourseMatch : Entity
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

        public CourseMatch()
        {
            Student = new Student();
            Course = new Course();
        }

        public CourseMatch(int id, int studentId, int courseId) : base(id)
        {
            Id = id;
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}
