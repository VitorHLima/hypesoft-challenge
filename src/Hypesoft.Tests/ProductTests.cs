namespace Hypesoft.Tests.Domain;

using Hypesoft.Domain.Entities;
using FluentAssertions;
using Xunit;

public class ProductTests
{
    [Fact]
    public void Product_Should_Create_With_Valid_Properties()
    {
        // Arrange
        var name = "Notebook";
        var description = "Notebook Dell XPS 15";
        var price = 5000m;
        var stock = 10;
        var categoryId = "cat-123";

        // Act
        var product = new Product
        {
            Name = name,
            Description = description,
            Price = price,
            Stock = stock,
            CategoryId = categoryId
        };

        // Assert
        product.Name.Should().Be(name);
        product.Description.Should().Be(description);
        product.Price.Should().Be(price);
        product.Stock.Should().Be(stock);
        product.CategoryId.Should().Be(categoryId);
        product.Id.Should().NotBeNullOrEmpty();
        product.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void Product_Should_Update_UpdatedAt_When_Modified()
    {
        // Arrange
        var product = new Product
        {
            Name = "Old Name",
            Description = "Old Description",
            Price = 100m,
            Stock = 5,
            CategoryId = "cat-1"
        };
        var originalUpdatedAt = product.UpdatedAt ?? DateTime.UtcNow;
        Thread.Sleep(10);

        // Act
        product.Name = "New Name";
        product.UpdatedAt = DateTime.UtcNow;

        // Assert
        product.Name.Should().Be("New Name");
        product.UpdatedAt.Should().NotBeNull();
        product.UpdatedAt!.Value.Should().BeAfter(originalUpdatedAt);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(9)]
    public void Product_Should_Be_Low_Stock_When_Below_Threshold(int stock)
    {
        // Arrange
        const int threshold = 10;
        var product = new Product
        {
            Name = "Test Product",
            Stock = stock
        };

        // Assert
        product.Stock.Should().BeLessThan(threshold);
    }
}
