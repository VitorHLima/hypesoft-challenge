namespace Hypesoft.Domain.Repositories;

using Hypesoft.Domain.Entities;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync(int page, int pageSize, string? search = null, string? categoryId = null);
    Task<Product?> GetByIdAsync(string id);
    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task DeleteAsync(string id);
    Task<IEnumerable<Product>> GetLowStockAsync(int threshold = 10);
    Task<int> CountAsync(string? search = null, string? categoryId = null);
}
