namespace Hypesoft.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Hypesoft.Domain.Repositories;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public DashboardController(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var products = await _productRepository.GetAllAsync(1, 10000);
        var categories = await _categoryRepository.GetAllAsync();
        var lowStockProducts = await _productRepository.GetLowStockAsync(10);
        var totalProducts = await _productRepository.CountAsync();

        var productsList = products.ToList();
        var totalValue = productsList.Sum(p => p.Price * p.Stock);

        return Ok(new
        {
            TotalProducts = totalProducts,
            TotalCategories = categories.Count(),
            LowStockCount = lowStockProducts.Count(),
            TotalValue = totalValue
        });
    }

    [HttpGet("sales")]
    public IActionResult GetSalesData()
    {
        var salesData = new[]
        {
            new { month = "Jan", sales = 4000 },
            new { month = "Fev", sales = 3000 },
            new { month = "Mar", sales = 5000 },
            new { month = "Abr", sales = 4500 },
            new { month = "Mai", sales = 6000 },
            new { month = "Jun", sales = 5500 },
        };

        return Ok(salesData);
    }
}
