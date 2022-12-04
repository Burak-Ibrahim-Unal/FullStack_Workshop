using Domain.Entities.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace API.Controllers
{
    [Authorize]
    public class OrdersController : BaseApiController
    {
        private readonly BaseDbContext _baseDbContext;

        public OrdersController(BaseDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            return await _baseDbContext.Orders
                .Include(o => o.OrderItems)
                .Where(x => x.BuyerId == User.Identity.Name)
                .ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            return await _baseDbContext.Orders
                .Include(o => o.OrderItems)
                .Where(x => x.BuyerId == User.Identity.Name && x.Id = id)
                .FirstOrDefaultAsync();

        }
    }
}
