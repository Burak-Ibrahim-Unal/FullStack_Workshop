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
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext nc = new NorthwindContext())
            {
                var DbResult = from p in nc.Products
                               join c in nc.Categories
                               on p.CategoryId equals c.CategoryId
                               where p.UnitPrice > 10 && p.UnitsInStock < 10
                               orderby p.UnitsInStock
                               select new ProductDetailDto { ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitPrice = p.UnitPrice, UnitStock = p.UnitsInStock };
                return DbResult.ToList();
            }
        }
    }
}
