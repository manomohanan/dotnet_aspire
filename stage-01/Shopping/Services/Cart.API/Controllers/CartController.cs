using Cart.Application.Commands;
using Cart.Application.Responses;
using Cart.Core.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMediator _mediator;
        public CartController(ICartRepository cartRepository , IMediator mediator) { 
        _cartRepository = cartRepository;
            _mediator = mediator;
        }
        [HttpPost("CreateBasket")]
        [ProducesResponseType(typeof(ShoppingCartResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartResponse>> UpdateBasket([FromBody] CreateShoppingCartCommand createShoppingCartCommand)
        {

            var basket = await _mediator.Send(createShoppingCartCommand);
            return Ok(basket);
        }
    }
}
