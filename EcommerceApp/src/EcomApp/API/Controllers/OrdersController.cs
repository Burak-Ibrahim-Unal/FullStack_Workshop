using API.DTOs;
using API.Extensions;
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

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(CreateOrderDto createOrderDto)
        {
            var basket = await _baseDbContext.Baskets
                .RetrieveBasketWithItems(User.Identity.Name)
                .FirstOrDefaultAsync();

            if (basket == null) return BadRequest(new ProblemDetails { Title = "Couldnt locate basket" });

            var items = new List<OrderItem>();

            foreach (var item in basket.Items)
            {
                var productItem = await _baseDbContext.Products.FindAsync(item.ProductId);
                var orderedProductItem = new OrderedProductItem
                {
                    ProductId = productItem.Id,
                    Name = productItem.Name,
                    PictureUrl = productItem.PictureUrl,
                };
                var orderItem = new OrderItem
                {
                    OrderedProductItem = orderedProductItem,
                    Price = productItem.Price,
                    Quantity = item.Quantity,
                };
                items.Add(orderItem);

                productItem.StockQuantity -= item.Quantity;


            }
        }
    }
}
