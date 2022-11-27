using Domain.Entites;

namespace API.Extensions
{
    public static class CourseExtensions
    {
        public static IQueryable<Course> Sort(this IQueryable<Course> query, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(p => p.CourseId);

            query = orderBy switch
            {
                "courseid" => query.OrderBy(p => p.CourseId),
                "courseidDesc" => query.OrderByDescending(p => p.CourseId),
                "coursename" => query.OrderBy(p => p.CourseName),
                "coursenameDesc" => query.OrderByDescending(p => p.CourseName),
                _ => query.OrderBy(p => p.CourseId),
            };

            return query;
        }

        public static IQueryable<Course> SearchCourseId(this IQueryable<Course> query, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return query;

            var lowerCaseSearch = searchTerm.Trim().ToLower();

            return query.Where(p => p.CourseId.ToLower().Contains(lowerCaseSearch));
        }     

        public static IQueryable<Course> SearchCourseName(this IQueryable<Course> query, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return query;

            var lowerCaseSearch = searchTerm.Trim().ToLower();

            return query.Where(p => p.CourseName.ToLower().Contains(lowerCaseSearch));
        }
    }
}
