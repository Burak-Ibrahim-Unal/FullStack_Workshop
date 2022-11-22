using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Basket : Entity
    {
        public string BuyerId { get; set; }
        public virtual ICollection<BasketItem> Items { get; set; }

        public Basket()
        {
            Items = new HashSet<BasketItem>();
        }

        public Basket(int id, string buyerId) : base(id)
        {
            Id = id;
            BuyerId = buyerId;
        }

        public void AddItem(Product product, int quantity)
        {
            if (Items.All(item => item.ProductId != product.Id))
            {
                Items.Add(new BasketItem { Product = product, Quantity = quantity });
            }

            var existingBasketItem = Items.FirstOrDefault(item => item.ProductId == product.Id);
            if (existingBasketItem != null) existingBasketItem.Quantity += quantity;
        }

        public void RemoveItem(int productId, int quantity)
        {
            var existingBasketItem = Items.FirstOrDefault(item => item.ProductId == productId);
            if (existingBasketItem == null) return;
            existingBasketItem.Quantity -= quantity;
            if (existingBasketItem.Quantity == 0) Items.Remove(existingBasketItem);
        }
    }
}
