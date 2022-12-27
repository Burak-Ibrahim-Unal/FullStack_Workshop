using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Order
{
    public class Order : Entity
    {
        public string BuyerId { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<OrderItem> OrderItems { get; set; }
        public double Subtotal { get; set; }
        public double DeliveryFee { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public string? PaymentIntentId { get; set; }

        public double GetTotal()
        {
            return Subtotal + DeliveryFee;
        }

        public Order()
        {

        }

        public Order(int id,string buyerId, ShippingAddress shippingAddress, DateTime orderDate,double subtotal,double deliveryFee, OrderStatus orderStatus,string paymentIntentId): base(id)
        {
            Id= id;
            BuyerId= buyerId;
            ShippingAddress= shippingAddress;
            DeliveryFee= deliveryFee;
            OrderStatus= orderStatus;
            PaymentIntentId= paymentIntentId;
            Subtotal = subtotal;
            OrderDate= orderDate;
        }
    }
}
