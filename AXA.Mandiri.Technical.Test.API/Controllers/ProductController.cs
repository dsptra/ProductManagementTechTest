using AXA.Mandiri.Technical.Test.Application.Features.Product.Command.AddProduct;
using AXA.Mandiri.Technical.Test.Application.Features.Product.Command.DeleteProduct;
using AXA.Mandiri.Technical.Test.Application.Features.Product.Command.EditProduct;
using AXA.Mandiri.Technical.Test.Application.Features.Product.Query.GetProductById;
using AXA.Mandiri.Technical.Test.Application.Features.Product.Query.SearchProduct;
using AXA.Mandiri.Technical.Test.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AXA.Mandiri.Technical.Test.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? name, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new SearchProductQuery { Name = name, MinPrice = minPrice, MaxPrice = maxPrice }, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductByIdQuery { Id = id }, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductRequestDto request, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new AddProductCommand
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            }, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] ProductRequestDto request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new EditProductCommand
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            }, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id }, cancellationToken);
            return NoContent();
        }
    }
}
