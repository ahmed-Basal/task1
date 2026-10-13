using ApiVersioningDemo.Models.V2;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningDemo.Controllers.V2;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly List<ProductV2> Products = new()
    {
        new ProductV2
        {
            Id = 1,
            Name = "Laptop Dell XPS 15",
            Price = 1500.00m,
            CategoryName = "Computers & Laptops",
            InStock = true,
            Description = "15-inch display, Intel Core i7 processor, 32GB RAM, 1TB SSD"
        },
        new ProductV2
        {
            Id = 2,
            Name = "iPhone 15 Pro Max",
            Price = 1200.00m,
            CategoryName = "Smartphones",
            InStock = true,
            Description = "Titanium design with A17 Pro chip and advanced camera system"
        },
        new ProductV2
        {
            Id = 3,
            Name = "Sony WH-1000XM5 Headphones",
            Price = 380.00m,
            CategoryName = "Audio & Accessories",
            InStock = false,
            Description = "Industry-leading noise cancellation with auto NC optimizer"
        },
        new ProductV2
        {
            Id = 4,
            Name = "Mechanical Keyboard RGB",
            Price = 120.00m,
            CategoryName = "Peripherals",
            InStock = true,
            Description = "RGB backlit custom mechanical switches with USB-C connection"
        }
    };

    /// <summary>
    /// Retrieves all products in the modern (V2) format.
    /// </summary>
    /// <remarks>
    /// This endpoint represents the upgraded API version. It returns a structured response envelope
    /// including metadata (success flag, total count, apiVersion) and includes additional product properties like CategoryName, Description, and InStock status.
    /// </remarks>
    /// <response code="200">Returns the enveloped list of products with enhanced schema.</response>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseV2<IEnumerable<ProductV2>>), StatusCodes.Status200OK)]
    public ActionResult<ApiResponseV2<IEnumerable<ProductV2>>> Get()
    {
        var response = new ApiResponseV2<IEnumerable<ProductV2>>
        {
            Success = true,
            ApiVersion = "2.0",
            Message = "Products retrieved successfully in V2 format.",
            TotalCount = Products.Count,
            Data = Products
        };

        return Ok(response);
    }

    /// <summary>
    /// Retrieves a single product by its unique ID in the modern (V2) format.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    /// <response code="200">Returns the product wrapped in the V2 response envelope.</response>
    /// <response code="404">If the product with the specified ID was not found.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ApiResponseV2<ProductV2>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponseV2<ProductV2>), StatusCodes.Status404NotFound)]
    public ActionResult<ApiResponseV2<ProductV2>> GetById(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound(new ApiResponseV2<ProductV2>
            {
                Success = false,
                ApiVersion = "2.0",
                Message = $"Product with ID {id} was not found.",
                TotalCount = 0,
                Data = null
            });
        }

        return Ok(new ApiResponseV2<ProductV2>
        {
            Success = true,
            ApiVersion = "2.0",
            Message = "Product details retrieved successfully.",
            TotalCount = 1,
            Data = product
        });
    }
}
