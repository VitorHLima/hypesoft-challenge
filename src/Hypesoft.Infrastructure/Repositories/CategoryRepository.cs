namespace Hypesoft.Infrastructure.Repositories;

using MongoDB.Driver;
using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;
using Hypesoft.Infrastructure.Data;

public class CategoryRepository : ICategoryRepository
{
    private readonly IMongoCollection<Category> _categories;

    public CategoryRepository(DatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _categories = database.GetCollection<Category>(settings.CategoriesCollectionName);
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _categories.Find(_ => true).ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(string id)
    {
        return await _categories.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Category> CreateAsync(Category category)
    {
        await _categories.InsertOneAsync(category);
        return category;
    }

    public async Task DeleteAsync(string id)
    {
        await _categories.DeleteOneAsync(x => x.Id == id);
    }
}
