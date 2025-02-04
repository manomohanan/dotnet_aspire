using System.ComponentModel.DataAnnotations;

namespace ECommerce.ProductService.Domain
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        
        [StringLength(100)]
        public string? Description { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public double Price { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        public Category Category { get; set; } = null!;
    }
}
