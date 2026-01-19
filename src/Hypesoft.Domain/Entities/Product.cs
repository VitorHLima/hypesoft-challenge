namespace Hypesoft.Domain.Entities;

using Hypesoft.Domain.Common;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string CategoryId { get; set; } = string.Empty;
    public int Stock { get; set; }
    
    // Navigation property
    public Category? Category { get; set; }
}
