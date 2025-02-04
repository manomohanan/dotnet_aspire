using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.Domain.Abstractions
{
    public interface ICategoryRepository
    {
        Task<bool> CategoryExistsAsync(int categoryId);
    }
}
