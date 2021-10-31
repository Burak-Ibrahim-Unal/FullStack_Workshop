using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
        public List<Category> GetCategorys()
        {
            using (NorthwindContext nc = new NorthwindContext())
            {
                var DbResult = from c in nc.Categories
                               orderby c.CategoryName
                               select new Category { CategoryId = c.CategoryId, CategoryName = c.CategoryName };
                return DbResult.ToList();
            }
        }
    }
}
