using API.Extensions;
using API.Helpers;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Text.Json;

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
        public async Task<ActionResult<PagedList<Product>>> GetProducts([FromQuery] ProductParams productParams)
        {
            var query = _baseDbContext.Products
                .Sort(productParams.OrderBy)
                .SearchName(productParams.SearchTerm)
                .Filter(productParams.Brands, productParams.Types)
                .AsQueryable();

            var products = await PagedList<Product>.ToPageList(query, productParams.PageNumber, productParams.PageSize);

            Response.AddPaginationHeader(products.MetaData);

            return products;
        }

        [HttpGet("{id}")] // api/product/1
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _baseDbContext.Products.FindAsync(id);

            if (product == null) return NotFound();

            return product;
        }

        [HttpGet("filters")]
        public async Task<IActionResult> GetFilters()
        {
            var brands = await _baseDbContext.Products.Select(x => x.Brand).Distinct().ToListAsync();
            var types = await _baseDbContext.Products.Select(x => x.Type).Distinct().ToListAsync();

            return Ok(new {brands,types});

        }

    }
}
