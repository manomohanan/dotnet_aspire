using Cart.Core.Entities;
using Cart.Core.IRepositories;
using Cart.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly CartDbContext _cartContext;
        public CartRepository(CartDbContext cartContext) { 
        _cartContext = cartContext;
        }
        public async Task<List<ShoppingCart>> GetCart(string userName)
        {
           return await _cartContext.ShoppingCart.ToListAsync();
        }

        public async Task<ShoppingCart> UpdateCart(ShoppingCart shoppingCart)
        {
             ShoppingCart a = new ShoppingCart();
            return a;
        }
        public async Task DeleteCart(string userName)
        {

        }
    }
}
