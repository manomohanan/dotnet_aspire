namespace ECommerce.ProductService.Domain.Abstractions
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts(CancellationToken token);
    }
}
