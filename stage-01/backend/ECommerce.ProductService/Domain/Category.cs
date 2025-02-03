using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.ProductService.Domain
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
        
        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
