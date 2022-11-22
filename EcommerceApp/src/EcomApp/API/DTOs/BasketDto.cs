using Core.Persistence.Repositories;

namespace API.DTOs
{
    public class BasketDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public virtual ICollection<BasketItemDto> Items { get; set; }
    }
}
