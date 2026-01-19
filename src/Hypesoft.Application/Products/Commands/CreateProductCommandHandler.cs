namespace Hypesoft.Application.Products.Commands;

using MediatR;
using Hypesoft.Application.Common.DTOs;
using Hypesoft.Domain.Repositories;
using Hypesoft.Domain.Entities;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CreateProductCommandHandler(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CategoryId = request.CategoryId,
            Stock = request.Stock
        };

        var createdProduct = await _productRepository.CreateAsync(product);
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

        return new ProductDto
        {
            Id = createdProduct.Id,
            Name = createdProduct.Name,
            Description = createdProduct.Description,
            Price = createdProduct.Price,
            CategoryId = createdProduct.CategoryId,
            CategoryName = category?.Name,
            Stock = createdProduct.Stock,
            CreatedAt = createdProduct.CreatedAt,
            UpdatedAt = createdProduct.UpdatedAt
        };
    }
}
