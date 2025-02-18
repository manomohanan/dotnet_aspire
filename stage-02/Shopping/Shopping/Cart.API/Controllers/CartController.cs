using Cart.Application.Commands;
using Cart.Application.Queries;
using Cart.Application.Responses;
using Cart.Core.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        [HttpGet]
        [Route("[action]/{userName}", Name = "GetBasketByUserName")]
        [ProducesResponseType(typeof(ShoppingCartResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartResponse>> GetBasket(string userName)
        {
            var query = new GetBasketByUserNameQuery(userName);
            var basket = await _mediator.Send(query);
            return Ok(basket);
        }

        [HttpDelete]
        [Route("[action]/{userName}", Name = "DeleteBasketByUserName")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            var query = new DeleteBasketByUserNameQuery(userName);
            var result = await _mediator.Send(query);

            if (result)
            {
                return Ok($"Shopping cart for user '{userName}' has been deleted successfully.");
            }
            else
            {
                return BadRequest($"Shopping cart for user '{userName}' not found.");
            }
        }
    }
}
