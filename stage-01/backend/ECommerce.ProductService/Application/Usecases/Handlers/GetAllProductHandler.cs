using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ECommerce.Common;
using ECommerce.ProductService.Application.UseCases.Queries;
using ECommerce.ProductService.Domain;
using ECommerce.ProductService.Infrastructure.Persistance;
using ECommerce.ProductService.Domain.Abstractions;

namespace ECommerce.ProductService.Application.Usecases.Handlers
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, ResponseBase<IEnumerable<Product>>>
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<GetAllProductHandler> logger;

        public GetAllProductHandler(IProductRepository repository, ILogger<GetAllProductHandler> _logger)
        {
            _repository = repository;
            logger = _logger;
        }

        public async Task<ResponseBase<IEnumerable<Product>>> Handle(GetAllProductQuery query, CancellationToken token)
        {
            var response = new ResponseBase<IEnumerable<Product>>()
            {
                Succcess = false,
                Data = null,
                Message = string.Empty
            };

            try
            {
                var products = await _repository.GetAllProducts(token);
                response.Succcess = true;
                response.Data = products;
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get product list: {ex.GetBaseException().ToString()}");
                response.Message = "Failed to get product list";
            }

            return response;
        }
    }
}
