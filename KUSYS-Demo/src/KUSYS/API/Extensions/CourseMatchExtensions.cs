using Application.Features.CourseMatches.Dtos;
using Domain.Entites;
using Microsoft.AspNetCore.Mvc;

namespace API.Extensions
{
    public static class CourseMatchExtensions
    {
        public static IQueryable<CourseMatchListDto> Sort(this IQueryable<CourseMatchListDto> query, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(p => p.CourseId);

            query = orderBy switch
            {
                "courseid" => query.OrderBy(p => p.CourseId),
                "courseidDesc" => query.OrderByDescending(p => p.CourseId),
                "coursename" => query.OrderBy(p => p.CourseName),
                "coursenameDesc" => query.OrderByDescending(p => p.CourseName),
                "firstname" => query.OrderBy(p => p.StudentFirstName),
                "firstnameDesc" => query.OrderByDescending(p => p.StudentFirstName),
                "lastname" => query.OrderBy(p => p.StudentLastName),
                "lastnameDesc" => query.OrderByDescending(p => p.StudentLastName),
                _ => query.OrderBy(p => p.CourseId),
            };

            return query;
        }

        public static IQueryable<CourseMatchDto> SearchCourseId(this IQueryable<CourseMatchDto> query, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return query;

            var lowerCaseSearch = searchTerm.Trim().ToLower();

            return query.Where(p => p.CourseId.ToLower().Contains(lowerCaseSearch));
        }     

        public static IQueryable<CourseMatchDto> SearchCourseName(this IQueryable<CourseMatchDto> query, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return query;

            var lowerCaseSearch = searchTerm.Trim().ToLower();

            return query.Where(p => p.CourseName.ToLower().Contains(lowerCaseSearch));
        }

        public static IQueryable<CourseMatchDto> Filter(this IQueryable<CourseMatchDto> query, string courses, string studentFirstNames, string studentLastNames)
        {
            var coursesList = new List<string>();
            var studentFirstNameList = new List<string>();
            var studentLastNameList = new List<string>();

            if (!string.IsNullOrEmpty(courses))
                coursesList.AddRange(courses.ToLower().Split(",").ToList()); 
            
            if (!string.IsNullOrEmpty(studentFirstNames))
                studentFirstNameList.AddRange(studentFirstNames.ToLower().Split(",").ToList());  
            
            if (!string.IsNullOrEmpty(studentLastNames))
                studentLastNameList.AddRange(studentLastNames.ToLower().Split(",").ToList());

            query = query.Where(p => coursesList.Count == 0 || coursesList.Contains(p.CourseId.ToLower()));
            query = query.Where(p => studentFirstNameList.Count == 0 || studentFirstNameList.Contains(p.StudentFirstName.ToLower()));
            query = query.Where(p => studentLastNameList.Count == 0 || studentLastNameList.Contains(p.StudentLastName.ToLower()));

            return query;
        }
    }
}