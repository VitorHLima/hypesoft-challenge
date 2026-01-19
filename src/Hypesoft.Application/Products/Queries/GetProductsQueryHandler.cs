namespace Hypesoft.Application.Products.Queries;

using MediatR;
using Hypesoft.Application.Common.DTOs;
using Hypesoft.Domain.Repositories;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, (IEnumerable<ProductDto> Products, int Total)>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public GetProductsQueryHandler(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<(IEnumerable<ProductDto> Products, int Total)> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(
            request.Page,
            request.PageSize,
            request.Search,
            request.CategoryId);

        var total = await _productRepository.CountAsync(request.Search, request.CategoryId);

        var categories = await _categoryRepository.GetAllAsync();
        var categoryDict = categories.ToDictionary(c => c.Id, c => c.Name);

        var productDtos = products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            CategoryId = p.CategoryId,
            CategoryName = categoryDict.GetValueOrDefault(p.CategoryId),
            Stock = p.Stock,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt
        });

        return (productDtos, total);
    }
}
