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
    public class DeleteBasketByUserNameHandler : IRequestHandler<DeleteBasketByUserNameQuery , bool>
    {
        private readonly ICartRepository _cartRepository;

        public DeleteBasketByUserNameHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<bool> Handle(DeleteBasketByUserNameQuery request, CancellationToken cancellationToken)
        {
            return await _cartRepository.DeleteCart(request.UserName);
        }
    }
}
