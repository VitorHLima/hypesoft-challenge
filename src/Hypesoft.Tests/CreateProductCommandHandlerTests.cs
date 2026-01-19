namespace Hypesoft.Tests.Application;

using Hypesoft.Application.Products.Commands;
using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

public class CreateProductCommandHandlerTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
    private readonly CreateProductCommandHandler _handler;

    public CreateProductCommandHandlerTests()
    {
        _productRepositoryMock = new Mock<IProductRepository>();
        _categoryRepositoryMock = new Mock<ICategoryRepository>();
        _handler = new CreateProductCommandHandler(
            _productRepositoryMock.Object,
            _categoryRepositoryMock.Object
        );
    }

    [Fact]
    public async Task Handle_Should_Create_Product_Successfully()
    {
        // Arrange
        var command = new CreateProductCommand
        {
            Name = "Notebook",
            Description = "Dell XPS 15",
            Price = 5000m,
            Stock = 10,
            CategoryId = "cat-123"
        };

        var category = new Category { Id = "cat-123", Name = "Eletrônicos" };
        var createdProduct = new Product
        {
            Id = "prod-123",
            Name = command.Name,
            Description = command.Description,
            Price = command.Price,
            Stock = command.Stock,
            CategoryId = command.CategoryId
        };

        _productRepositoryMock
            .Setup(x => x.CreateAsync(It.IsAny<Product>()))
            .ReturnsAsync(createdProduct);

        _categoryRepositoryMock
            .Setup(x => x.GetByIdAsync(command.CategoryId))
            .ReturnsAsync(category);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be("prod-123");
        result.Name.Should().Be(command.Name);
        result.Price.Should().Be(command.Price);
        result.CategoryName.Should().Be("Eletrônicos");

        _productRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<Product>()), Times.Once);
        _categoryRepositoryMock.Verify(x => x.GetByIdAsync(command.CategoryId), Times.Once);
    }

    [Fact]
    public async Task Handle_Should_Create_Product_Even_When_Category_Not_Found()
    {
        // Arrange
        var command = new CreateProductCommand
        {
            Name = "Mouse",
            Description = "Mouse Gamer",
            Price = 150m,
            Stock = 50,
            CategoryId = "non-existent"
        };

        var createdProduct = new Product
        {
            Id = "prod-456",
            Name = command.Name,
            Description = command.Description,
            Price = command.Price,
            Stock = command.Stock,
            CategoryId = command.CategoryId
        };

        _productRepositoryMock
            .Setup(x => x.CreateAsync(It.IsAny<Product>()))
            .ReturnsAsync(createdProduct);

        _categoryRepositoryMock
            .Setup(x => x.GetByIdAsync(command.CategoryId))
            .ReturnsAsync((Category?)null);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.CategoryName.Should().BeNull();
    }
}
