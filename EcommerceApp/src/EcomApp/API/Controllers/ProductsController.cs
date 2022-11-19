using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Contexts;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly BaseDbContext _baseDbContext;

        public ProductsController(BaseDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = _baseDbContext.Products.ToList();

            return Ok(products);
        }

        [HttpGet("{id}")] // api/product/1
        public ActionResult<Product> GetProduct(int id)
        {
            return _baseDbContext.Products.Find(id);
        }

    }
}
