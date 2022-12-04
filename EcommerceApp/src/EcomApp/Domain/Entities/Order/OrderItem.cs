using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Order
{
    public class OrderItem : Entity
    {
        public OrderedProductItem OrderedProductItem { get; set; }
        public long Price { get; set; }
        public int Quantity { get; set; }
    }
}
