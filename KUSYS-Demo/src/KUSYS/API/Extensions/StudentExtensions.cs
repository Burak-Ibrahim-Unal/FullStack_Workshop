using Domain.Entites;

namespace API.Extensions
{
    public static class StudentExtensions
    {
        public static IQueryable<Student> Sort(this IQueryable<Student> query, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(p => p.FirstName);

            query = orderBy switch
            {
                "firstname" => query.OrderBy(p => p.FirstName),
                "firstnameDesc" => query.OrderByDescending(p => p.FirstName),           
                "lastname" => query.OrderBy(p => p.LastName),
                "lastnameDesc" => query.OrderByDescending(p => p.LastName),
                _ => query.OrderBy(p => p.FirstName),
            };

            return query;
        }

        public static IQueryable<Student> SearchFirstName(this IQueryable<Student> query, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return query;

            var lowerCaseSearch = searchTerm.Trim().ToLower();

            return query.Where(p => p.FirstName.ToLower().Contains(lowerCaseSearch));
        }     

        public static IQueryable<Student> SearchLastName(this IQueryable<Student> query, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return query;

            var lowerCaseSearch = searchTerm.Trim().ToLower();

            return query.Where(p => p.LastName.ToLower().Contains(lowerCaseSearch));
        }

        //public static IQueryable<Student> Filter(this IQueryable<Student> query, string brands, string types)
        //{
        //    var brandList = new List<string>();

        //    if (!string.IsNullOrEmpty(brands))
        //        brandList.AddRange(brands.ToLower().Split(",").ToList()); 
            
        //    query = query.Where(p => brandList.Count == 0 || brandList.Contains(p.Brand.ToLower()));

        //    return query;
        //}
    }
}
