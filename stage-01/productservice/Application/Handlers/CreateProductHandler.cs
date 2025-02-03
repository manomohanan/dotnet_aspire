using Application.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IStorageService _storageService;

        public CreateProductHandler(IProductRepository productRepository, IStorageService storageService)
        {
            _productRepository = productRepository;
            _storageService = storageService;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            string imageUrl = string.Empty;

            // Upload image to Azure Blob Storage if provided
            if (request.Image != null)
            {
                using var stream = request.Image.OpenReadStream();
                imageUrl = await _storageService.UploadFileAsync(stream, request.Image.FileName, request.Image.ContentType);
            }

            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                ImageUrl = imageUrl
            };

            await _productRepository.AddAsync(product);
            return product.Id;
        }
    }
}
