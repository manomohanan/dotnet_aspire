using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.Application.Usecases.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        public IFormFile? Image { get; set; }
    }
}
