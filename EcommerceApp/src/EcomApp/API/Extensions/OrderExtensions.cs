using API.DTOs;
using Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class OrderExtensions
    {
        public static IQueryable<OrderDto> ProjectOrderToOrderDto(this IQueryable<Order> query)
        {
            return query.Select(order => new OrderDto
            {
                Id = order.Id,
                BuyerId = order.BuyerId,
                OrderDate = order.OrderDate,
                ShippingAddress = order.ShippingAddress,
                DeliveryFee = order.DeliveryFee,
                Subtotal = order.Subtotal,
                OrderStatus = order.OrderStatus.ToString(),
                TotalCost = order.GetTotal(),
                OrderItems = order.OrderItems.Select(item => new OrderItemDto
                {
                    ProductId = item.OrderedProductItem.ProductId,
                    Name = item.OrderedProductItem.Name,
                    PictureUrl = item.OrderedProductItem.PictureUrl,
                    Price = item.Price,
                    Quantity = item.Quantity,
                }).ToList()
            }).AsNoTracking();
        }
    }
}
