namespace Hypesoft.Infrastructure.Data;

public class DatabaseSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string ProductsCollectionName { get; set; } = "Products";
    public string CategoriesCollectionName { get; set; } = "Categories";
}
