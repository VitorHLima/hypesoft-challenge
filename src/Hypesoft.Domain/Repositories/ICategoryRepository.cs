namespace Hypesoft.Domain.Repositories;

using Hypesoft.Domain.Entities;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(string id);
    Task<Category> CreateAsync(Category category);
    Task DeleteAsync(string id);
}
