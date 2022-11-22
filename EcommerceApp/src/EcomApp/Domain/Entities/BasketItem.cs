using Core.Persistence.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("BasketItems")]
    public class BasketItem : Entity
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int BasketId { get; set; }

        public Product Product { get; set; }
        public Basket Basket { get; set; }

        public BasketItem()
        {

        }

        public BasketItem(int id,int quantity,int productId,int basketID): base(id) 
        {
            Id = id;
            Quantity = quantity;
            ProductId = productId;
            BasketId= basketID;
        }
    }
}