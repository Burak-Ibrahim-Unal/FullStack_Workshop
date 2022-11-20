using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly BaseDbContext _baseDbContext;

        public ProductsController(BaseDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await _baseDbContext.Products.ToListAsync();
        }

        [HttpGet("{id}")] // api/product/1
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _baseDbContext.Products.FindAsync(id);
        }

    }
}
