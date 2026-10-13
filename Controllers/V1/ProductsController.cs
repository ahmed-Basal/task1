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
    /// Retrieves all products in the legacy (V1) format.
    /// </summary>
    /// <remarks>
    /// This endpoint serves existing/legacy clients by returning a flat array of products with basic fields (ID, Name, Price).
    /// </remarks>
    /// <response code="200">Returns the list of products in the original format.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductV1>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<ProductV1>> Get()
    {
        return Ok(Products);
    }

    /// <summary>
    /// Retrieves a single product by its unique ID in the legacy (V1) format.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    /// <response code="200">Returns the requested product.</response>
    /// <response code="404">If the product with the specified ID was not found.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ProductV1), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
