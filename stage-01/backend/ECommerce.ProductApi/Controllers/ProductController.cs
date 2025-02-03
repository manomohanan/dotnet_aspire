using ECommerce.ProductService.Application.UseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProductsAsync(CancellationToken token)
        {
            var response = await _mediator.Send(new GetAllProductQuery(), token);
            if (response.Succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
