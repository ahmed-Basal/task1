namespace ApiVersioningDemo.Models.V1;

/// <summary>
/// Represents a product in the legacy (V1) data model.
/// </summary>
public class ProductV1
{
    /// <summary>
    /// The unique product identifier.
    /// </summary>
    /// <example>1</example>
    public int Id { get; set; }

    /// <summary>
    /// The name of the product.
    /// </summary>
    /// <example>Laptop Dell XPS</example>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The price of the product in USD.
    /// </summary>
    /// <example>1500.00</example>
    public decimal Price { get; set; }
}
