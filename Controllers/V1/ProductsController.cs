using ApiVersioningDemo.Models.V1;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningDemo.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly List<ProductV1> Products = new()
    {
        new ProductV1 { Id = 1, Name = "Laptop Dell XPS", Price = 1500.00m },
        new ProductV1 { Id = 2, Name = "iPhone 15 Pro", Price = 1200.00m },
        new ProductV1 { Id = 3, Name = "Sony WH-1000XM5 Headphones", Price = 380.00m },
        new ProductV1 { Id = 4, Name = "Mechanical Keyboard", Price = 120.00m }
    };

    /// <summary>
    /// GET /api/v1/products - Returns product data in the legacy (v1) flat format.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<ProductV1>> Get()
    {
        return Ok(Products);
    }

    /// <summary>
    /// GET /api/v1/products/{id}
    /// </summary>
    [HttpGet("{id:int}")]
    public ActionResult<ProductV1> GetById(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound(new { message = $"Product with ID {id} not found." });
        }
        return Ok(product);
    }
}
