using Cart.Application.Commands;
using Cart.Application.Responses;
using Cart.Core.Entities;
using Cart.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Application.Handlers
{
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, ShoppingCartResponse>
    {
        private readonly ICartRepository _cartRepository;

        public CreateShoppingCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<ShoppingCartResponse> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
           
            var shoppingCart = await _cartRepository.UpdateCart(new ShoppingCart
            {
                UserName = request.UserName,
                Items = request.Items
            });
            ShoppingCartResponse shoppingCartResponse = new ShoppingCartResponse();
            return shoppingCartResponse;
        }
    }
}
