namespace Hypesoft.Application.Products.Queries;

using MediatR;
using Hypesoft.Application.Common.DTOs;

public class GetProductsQuery : IRequest<(IEnumerable<ProductDto> Products, int Total)>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Search { get; set; }
    public string? CategoryId { get; set; }
}
