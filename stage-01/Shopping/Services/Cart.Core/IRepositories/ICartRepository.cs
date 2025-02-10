using Cart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Core.IRepositories
{
    public interface ICartRepository
    {
        Task<List<ShoppingCart>> GetCart(string userName);
        Task<ShoppingCart> UpdateCart(ShoppingCart shoppingCart);
        Task DeleteCart(string userName);
    }
}
