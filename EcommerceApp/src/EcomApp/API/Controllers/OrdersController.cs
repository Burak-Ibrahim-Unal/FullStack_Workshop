using API.DTOs;
using API.Extensions;
using Domain.Entities;
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

        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            return await _baseDbContext.Orders
                .Include(o => o.OrderItems)
                .Where(x => x.BuyerId == User.Identity.Name && x.Id = id)
                .FirstOrDefaultAsync();

        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateOrder(CreateOrderDto createOrderDto)
        {
            var basket = await _baseDbContext.Baskets
                .RetrieveBasketWithItems(User.Identity.Name)
                .FirstOrDefaultAsync();

            if (basket == null) return BadRequest(new ProblemDetails { Title = "Could'nt locate basket" });

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

            var subTotal = items.Sum(item => item.Price * item.Quantity);
            var deliveryFee = subTotal > 10000 ? 0 : subTotal > 1000 ? 7 : 20;

            var order = new Order
            {
                OrderItems = items,
                BuyerId = User.Identity.Name,
                ShippingAddress = createOrderDto.ShippingAddress,
                Subtotal = subTotal,
                DeliveryFee = deliveryFee,
            };

            _baseDbContext.Orders.Add(order);
            _baseDbContext.Baskets.Remove(basket);

            if (createOrderDto.SaveAddress)
            {
                var user = await _baseDbContext.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);
                user.UserAddress = new UserAddress
                {
                    FullName = createOrderDto.ShippingAddress.FullName,
                    Address1 = createOrderDto.ShippingAddress.Address1,
                    Address2 = createOrderDto.ShippingAddress.Address2,
                    City = createOrderDto.ShippingAddress.City,
                    State = createOrderDto.ShippingAddress.State,
                    Zip = createOrderDto.ShippingAddress.Zip,
                    Country = createOrderDto.ShippingAddress.Country,
                };
                _baseDbContext.Update(user);
            }

            var result = await _baseDbContext.SaveChangesAsync() > 0;
            if (result) return CreatedAtRoute("GetOrder", new { id = order.Id }, order.Id);

            return BadRequest("Problem occured while creating order");
        }
    }
}
