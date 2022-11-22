using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class BasketItem : Entity
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public BasketItem()
        {

        }

        public BasketItem(int id,int quantity,int productId): base(id) 
        {
            Id = id;
            Quantity = quantity;
            ProductId = productId;
        }
    }
}