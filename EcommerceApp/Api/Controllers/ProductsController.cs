using API.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public string GetProducts()
        {
            return "all products";
        }

        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return id + " id product";
        }


    }
}