namespace ApiVersioningDemo.Models.V2;

public class ProductV2
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public bool InStock { get; set; }
    public string Description { get; set; } = string.Empty;
}
