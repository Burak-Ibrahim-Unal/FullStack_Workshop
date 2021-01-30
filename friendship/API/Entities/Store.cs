namespace API.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Company Company { get; set; }
        public int Quantity { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
                
    }
}