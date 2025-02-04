using ECommerce.ProductService.Domain.Abstractions;
using ECommerce.ProductService.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductContext dbContext;
        public CategoryRepository(ProductContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await dbContext.Category.AnyAsync(c => c.Id == categoryId);
        }
    }
}
