using ECommerce.ProductService.Application.Usecases.Commands;
using ECommerce.ProductService.Domain;
using ECommerce.ProductService.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.Application.Usecases.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IStorageService _storageService;
        public CreateProductHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IStorageService storageService) {
        _productRepository = productRepository;
            _storageService = storageService;
            _categoryRepository = categoryRepository;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var categoryExists = await _categoryRepository.CategoryExistsAsync(request.CategoryId);
            if (!categoryExists)
            {
                return 0;
            }
            string imageUrl = string.Empty;

            // Upload image to Azure Blob Storage if provided
            if (request.Image != null)
            {
                using var stream = request.Image.OpenReadStream();
                imageUrl = await _storageService.UploadFileAsync(stream, request.Image.FileName, request.Image.ContentType);
            }
            var product = new Product
            {
                ProductName = request.ProductName,
                Description = request.Description,
                CategoryId = request.CategoryId,
                Quantity = request.Quantity,
                Price = request.Price,
                CreatedDate = DateTime.UtcNow,
                ImageUrl = imageUrl
            };
            await _productRepository.AddAsync(product);
            return product.Id;
        }
    }
}
