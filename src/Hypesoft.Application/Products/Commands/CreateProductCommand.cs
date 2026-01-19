namespace Hypesoft.Application.Products.Commands;

using MediatR;
using Hypesoft.Application.Common.DTOs;

public class CreateProductCommand : IRequest<ProductDto>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string CategoryId { get; set; } = string.Empty;
    public int Stock { get; set; }
}
