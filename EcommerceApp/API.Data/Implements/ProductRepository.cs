using Api.Core.Entity;
using Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Implements
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
