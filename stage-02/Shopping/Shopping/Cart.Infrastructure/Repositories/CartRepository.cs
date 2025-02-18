using Azure.Core;
using Cart.Application.Responses;
using Cart.Core.Entities;
using Cart.Core.IRepositories;
using Cart.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cart.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly CartDbContext _cartContext;
        private readonly ILogger<CartRepository> _logger;
        public CartRepository(CartDbContext cartContext , ILogger<CartRepository> logger) { 
        _cartContext = cartContext;
            _logger = logger;
        }
        public async Task<ShoppingCartResponse> GetCart(string userName)
        {
            List<ShoppingCartItem> details =  await _cartContext.ShoppingCart
        .Where(cart => cart.UserName == userName)
        .SelectMany(cart => cart.Items)
        .ToListAsync();
            List<ShoppingCartItemResponse> shoppingCartItemResponses = details.ConvertAll(item => new ShoppingCartItemResponse
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Price = item.Price,
                ProductId = item.ProductId,
                ImageFile = item.ImageFile,
                ProductName = item.ProductName
            });
            return new ShoppingCartResponse
            {
                UserName = userName,
                Items = shoppingCartItemResponses
            };
        }

        public async Task<ShoppingCartResponse> UpdateCart(ShoppingCart shoppingCart)
        {
            var existingCart = await _cartContext.ShoppingCart
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserName == shoppingCart.UserName);

            if (existingCart == null)
            {
                var newCart = new ShoppingCart(shoppingCart.UserName);
                newCart.Items.AddRange(shoppingCart.Items);

                _cartContext.ShoppingCart.Add(newCart);
                await _cartContext.SaveChangesAsync();
                List<ShoppingCartItemResponse> shoppingCartItemResponses = newCart.Items.ConvertAll(item => new ShoppingCartItemResponse
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    ProductId = item.ProductId,
                    ImageFile = item.ImageFile,
                    ProductName = item.ProductName
                });

                ShoppingCartResponse results = new ShoppingCartResponse()
                {
                    Items = shoppingCartItemResponses,
                    UserName = shoppingCart.UserName
                };

                return results;
            }
            else
            {
                foreach (var item in shoppingCart.Items)
                {
                    var existingItem = existingCart.Items
                        .FirstOrDefault(i => i.ProductId == item.ProductId);

                    if (existingItem != null)
                    {
                        existingItem.Quantity = item.Quantity;
                        existingItem.Price = item.Price;
                    }
                    else
                    {
                        existingCart.Items.Add(item);
                    }
                }

                await _cartContext.SaveChangesAsync();

                List<ShoppingCartItemResponse> shoppingCartItemResponses = existingCart.Items.ConvertAll(item => new ShoppingCartItemResponse
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    ProductId = item.ProductId,
                    ImageFile = item.ImageFile,
                    ProductName = item.ProductName
                });

                return new ShoppingCartResponse
                {
                    UserName = shoppingCart.UserName,
                    Items = shoppingCartItemResponses
                };
            }
        }
        public async Task<bool> DeleteCart(string userName)
        {
            var shoppingCart = await _cartContext.ShoppingCart
             .Include(cart => cart.Items)
             .FirstOrDefaultAsync(cart => cart.UserName == userName);

            if (shoppingCart == null)
            {
                return false;
            }

            _cartContext.ShoppingCart.Remove(shoppingCart);
            await _cartContext.SaveChangesAsync();
            return true;
        }
    }
}
