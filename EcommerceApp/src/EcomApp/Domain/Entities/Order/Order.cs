﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Order
{
    public class Order : Entity
    {
        public int BuyerId { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<OrderItem> OrderItems { get; set; }
        public double Subtotal { get; set; }
        public double DeliveryFee { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

        public double GetTotal()
        {
            return Subtotal + DeliveryFee;
        }
    }
}
