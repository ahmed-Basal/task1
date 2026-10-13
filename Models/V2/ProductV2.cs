namespace ApiVersioningDemo.Models.V2;

/// <summary>
/// Represents an enhanced product in the modern (V2) data model.
/// </summary>
public class ProductV2
{
    /// <summary>
    /// The unique product identifier.
    /// </summary>
    /// <example>1</example>
    public int Id { get; set; }

    /// <summary>
    /// The detailed commercial name of the product.
    /// </summary>
    /// <example>Laptop Dell XPS 15</example>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The price of the product in USD.
    /// </summary>
    /// <example>1500.00</example>
    public decimal Price { get; set; }

    /// <summary>
    /// The category name the product belongs to (New in V2).
    /// </summary>
    /// <example>Computers &amp; Laptops</example>
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// Availability status indicating whether the item is in stock.
    /// </summary>
    /// <example>true</example>
    public bool InStock { get; set; }

    /// <summary>
    /// Comprehensive description of features and specifications.
    /// </summary>
    /// <example>15-inch display, Intel Core i7 processor, 32GB RAM, 1TB SSD</example>
    public string Description { get; set; } = string.Empty;
}
