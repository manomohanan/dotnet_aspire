using Cart.Application.Queries;
using Cart.Application.Responses;
using Cart.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Application.Handlers
{
    public class GetBasketByUserNameHandler : IRequestHandler<GetBasketByUserNameQuery, ShoppingCartResponse>
    {
        private readonly ICartRepository _cartRepository;

        public GetBasketByUserNameHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<ShoppingCartResponse> Handle(GetBasketByUserNameQuery request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _cartRepository.GetCart(request.UserName);
            ShoppingCartResponse shoppingCartResponse = new ShoppingCartResponse();
/*            var shoppingCartResponse = BasketMapper.Mapper.Map<ShoppingCartResponse>(shoppingCart);
*/            return shoppingCartResponse;
        }
    }
}
