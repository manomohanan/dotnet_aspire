using Cart.Application.Queries;
using Cart.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Application.Handlers
{
    public class DeleteBasketByUserNameHandler : IRequestHandler<DeleteBasketByUserNameQuery , Unit>
    {
        private readonly ICartRepository _cartRepository;

        public DeleteBasketByUserNameHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<Unit> Handle(DeleteBasketByUserNameQuery request, CancellationToken cancellationToken)
        {
            await _cartRepository.DeleteCart(request.UserName);
            return Unit.Value;
        }
    }
}
