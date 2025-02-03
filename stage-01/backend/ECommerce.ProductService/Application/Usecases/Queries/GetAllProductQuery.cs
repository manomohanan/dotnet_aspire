using ECommerce.Common;
using ECommerce.ProductService.Domain;
using MediatR;

namespace ECommerce.ProductService.Application.UseCases.Queries
{
    public class GetAllProductQuery : IRequest<ResponseBase<IEnumerable<Product>>>
    {
    }
}
