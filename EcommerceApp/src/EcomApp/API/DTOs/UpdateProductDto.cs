using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class UpdateProductDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, Double.PositiveInfinity)]
        public double Price { get; set; }

        public IFormFile? File { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        [Range(0, 1000)]
        public int StockQuantity { get; set; }
    }
}
