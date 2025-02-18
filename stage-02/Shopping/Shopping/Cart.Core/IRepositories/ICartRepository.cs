using Cart.Application.Responses;
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
        Task<ShoppingCartResponse> GetCart(string userName);
        Task<ShoppingCartResponse> UpdateCart(ShoppingCart shoppingCart);
        Task<bool> DeleteCart(string userName);
    }
}
