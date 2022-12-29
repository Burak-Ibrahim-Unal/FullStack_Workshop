﻿using API.DTOs;
using API.Extensions;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMapper _mapper;

        public ProductsController(BaseDbContext baseDbContext, IMapper mapper)
        {
            _baseDbContext = baseDbContext;
            _mapper = mapper;
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

        [HttpGet("{id}", Name = "GetProduct")] // api/product/1
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

            return Ok(new { brands, types });

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _baseDbContext.Products.Add(product);

            var result = await _baseDbContext.SaveChangesAsync() > 0;

            if (result) return CreatedAtRoute("GetProduct", new { Id = product.Id }, product);

            return BadRequest(new ProblemDetails { Title = "Problem occured while creating product" });
        }

    }
}
