namespace Hypesoft.API.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Hypesoft.Application.Products.Commands;
using Hypesoft.Application.Products.Queries;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(
        [FromQuery] int page = 1,
        [FromQuery] int limit = 10,
        [FromQuery] string? search = null,
        [FromQuery] string? category = null)
    {
        var query = new GetProductsQuery
        {
            Page = page,
            PageSize = limit,
            Search = search,
            CategoryId = category
        };

        var result = await _mediator.Send(query);
        
        return Ok(new
        {
            data = result.Products,
            total = result.Total,
            page,
            limit
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetProducts), new { id = result.Id }, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        var command = new DeleteProductCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
