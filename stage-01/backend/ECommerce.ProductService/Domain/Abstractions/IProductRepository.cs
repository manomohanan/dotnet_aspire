namespace ECommerce.ProductService.Domain.Abstractions
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts(CancellationToken token);
        Task AddAsync(Product product);
    }
}
