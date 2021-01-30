using System;
using System.Collections.Generic;

namespace API.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string Producer { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public ICollection<Photo> Photos { get; set; }


    }
}