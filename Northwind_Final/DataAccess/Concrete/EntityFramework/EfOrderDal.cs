using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, NorthwindContext>, IOrderDal
    {
        public List<OrderDetailDto> GetOrderDetails()
        {
            using (NorthwindContext nc = new NorthwindContext())
            {
                var DbResult = (from o in nc.Orders
                                join e in nc.Employees on o.EmployeeId equals e.EmployeeId
                                join c in nc.Customers on o.CustomerId equals c.CustomerId
                                where c.Address.Contains("57")
                                select new OrderDetailDto
                                {
                                    OrderId = o.OrderId,
                                    EmployeeFirstName = e.FirstName,
                                    EmployeeLastName = e.LastName,
                                    CompanyName = c.Address,
                                    ContactName = c.ContactName,
                                    Address = c.Address
                                }).ToList();
                return DbResult;

            }

        }
    }
}

// Code Example from https://www.tektutorialshub.com/entity-framework/join-query-entity-framework/
/*
 * using (AdventureWorks db = new AdventureWorks())
{
    var person = (from e in db.Employees
                  join p in db.People 
                  on e.BusinessEntityID equals p.BusinessEntityID
                  join s in db.SalesPersons 
                  on e.BusinessEntityID equals s.BusinessEntityID
                  join t in db.SalesTerritories 
                  on s.TerritoryID equals t.TerritoryID 
                  where t.CountryRegionCode == "CA"
                  select new
                      {
                          ID = e.BusinessEntityID,
                          FirstName = p.FirstName,
                          MiddleName = p.MiddleName,
                          LastName = p.LastName,
                          Region = t.CountryRegionCode
                  }).ToList();
*/
