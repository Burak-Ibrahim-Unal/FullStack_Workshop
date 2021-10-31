using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dto
{
    public class ProductDetailDto : IDto
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitStock { get; set; }

    }
}
