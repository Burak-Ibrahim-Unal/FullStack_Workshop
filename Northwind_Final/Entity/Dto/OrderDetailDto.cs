using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dto
{
    public class OrderDetailDto : IDto
    {
        public int OrderId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string Address { get; set; }
    }
}
