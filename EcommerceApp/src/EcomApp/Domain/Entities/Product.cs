using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? PictureUrl { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int StockQuantity { get; set; }
        public string? PublicId { get; set; }

        public Product()
        {

        }

        public Product(int id, string description, double price, string? pictureUrl, string type, string brand, int stockQuantity, string? publicId) : base(id)
        {
            Id = id;
            Description = description;
            Price = price;
            PictureUrl = pictureUrl;
            Type = type;
            Brand = brand;
            StockQuantity = stockQuantity;
            PublicId = publicId;
        }
    }
}
