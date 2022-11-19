using Domain.Entites;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public static class SeedData
    {
        public static void Initialize(BaseDbContext baseDbContext)
        {
            if (baseDbContext.CourseMatches.Any()) return;
            if (baseDbContext.Students.Any()) return;
            if (baseDbContext.Courses.Any()) return;

            var students = new List<Student>
            {
                new Student()
                {
                    FirstName = "Burak1",
                    LastName = "Unal1",
                    BirthDate= new DateTime(1987,7,22),
                },   
                new Student()
                {
                    FirstName = "Burak2",
                    LastName = "Unal2",
                    BirthDate= new DateTime(1987,5,29),
                },               
                new Student()
                {
                    FirstName = "Burak3",
                    LastName = "Unal3",
                    BirthDate= new DateTime(1987,11,02),
                },
                new Student()
                {
                    FirstName = "Burak4",
                    LastName = "Unal4",
                    BirthDate= new DateTime(1987,11,02),
                },
                new Student()
                {
                    FirstName = "Burak5",
                    LastName = "Unal5",
                    BirthDate= new DateTime(1987,11,02),
                },
            };

            var courses = new List<Course>
            {
                new Course()
                {
                    CourseId="CSI101",
                    CourseName="Introduction to Computer Science"
                },              
                new Course()
                {
                    CourseId="CSI102",
                    CourseName="Algorithms"
                },      
                new Course()
                {
                    CourseId="CSI101",
                    CourseName="Calculus"
                },   
                new Course()
                {
                    CourseId="CSI101",
                    CourseName="Physics"
                },
            };

            var CourseMatches = new List<CourseMatch>
            {
                new CourseMatch()
                {
                    Student = students[0],
                    Course  = courses[0]
                },              
                new CourseMatch()
                {
                    Student = students[0],
                    Course  = courses[1]
                },   
                new CourseMatch()
                {
                    Student = students[1],
                    Course  = courses[1]
                },   
                new CourseMatch()
                {
                    Student = students[1],
                    Course  = courses[2]
                },    
                new CourseMatch()
                {
                    Student = students[1],
                    Course  = courses[3]
                },  
                new CourseMatch()
                {
                    Student = students[2],
                    Course  = courses[0]
                },   
                new CourseMatch()
                {
                    Student = students[2],
                    Course  = courses[2]
                },    
                new CourseMatch()
                {
                    Student = students[3],
                    Course  = courses[2]
                },    
                new CourseMatch()
                {
                    Student = students[3],
                    Course  = courses[3]
                },    
                new CourseMatch()
                {
                    Student = students[3],
                    Course  = courses[4]
                },    
                new CourseMatch()
                {
                    Student = students[4],
                    Course  = courses[0]
                },    
                new CourseMatch()
                {
                    Student = students[4],
                    Course  = courses[4]
                },    
                new CourseMatch()
                {
                    Student = students[5],
                    Course  = courses[1]
                },    
                new CourseMatch()
                {
                    Student = students[5],
                    Course  = courses[3]
                },    
                new CourseMatch()
                {
                    Student = students[5],
                    Course  = courses[4]
                },
            };
        }
    }
}