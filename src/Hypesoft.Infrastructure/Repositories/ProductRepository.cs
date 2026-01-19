namespace Hypesoft.Infrastructure.Repositories;

using MongoDB.Driver;
using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;
using Hypesoft.Infrastructure.Data;

public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _products;

    public ProductRepository(DatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _products = database.GetCollection<Product>(settings.ProductsCollectionName);
    }

    public async Task<IEnumerable<Product>> GetAllAsync(int page, int pageSize, string? search = null, string? categoryId = null)
    {
        var filterBuilder = Builders<Product>.Filter;
        var filter = filterBuilder.Empty;

        if (!string.IsNullOrEmpty(search))
        {
            filter &= filterBuilder.Regex(x => x.Name, new MongoDB.Bson.BsonRegularExpression(search, "i"));
        }

        if (!string.IsNullOrEmpty(categoryId))
        {
            filter &= filterBuilder.Eq(x => x.CategoryId, categoryId);
        }

        return await _products.Find(filter)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(string id)
    {
        return await _products.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Product> CreateAsync(Product product)
    {
        await _products.InsertOneAsync(product);
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        product.UpdatedAt = DateTime.UtcNow;
        await _products.ReplaceOneAsync(x => x.Id == product.Id, product);
        return product;
    }

    public async Task DeleteAsync(string id)
    {
        await _products.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Product>> GetLowStockAsync(int threshold = 10)
    {
        return await _products.Find(x => x.Stock < threshold).ToListAsync();
    }

    public async Task<int> CountAsync(string? search = null, string? categoryId = null)
    {
        var filterBuilder = Builders<Product>.Filter;
        var filter = filterBuilder.Empty;

        if (!string.IsNullOrEmpty(search))
        {
            filter &= filterBuilder.Regex(x => x.Name, new MongoDB.Bson.BsonRegularExpression(search, "i"));
        }

        if (!string.IsNullOrEmpty(categoryId))
        {
            filter &= filterBuilder.Eq(x => x.CategoryId, categoryId);
        }

        return (int)await _products.CountDocumentsAsync(filter);
    }
}
