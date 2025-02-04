using ECommerce.ProductService.Domain;
using ECommerce.ProductService.Domain.Abstractions;
using ECommerce.ProductService.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ProductService.Infrastructure.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ProductContext dbContext;
        public ProductRepository(ProductContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProducts(CancellationToken token)
        {
            var result = await dbContext.Product.ToListAsync();
            return result;
        }
        public async Task AddAsync(Product product)
        {
            dbContext.Product.Add(product);
            await dbContext.SaveChangesAsync();
        }
    }
}
