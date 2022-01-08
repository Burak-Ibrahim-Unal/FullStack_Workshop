using Api.Data;
using Api.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProductsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = _dataContext.Products.ToList();
            return products;

        }

        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "product with id";
        }
    }
}