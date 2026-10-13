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
    /// GET /api/v2/products - Returns product data in the new (v2) format including CategoryName and enveloped response.
    /// </summary>
    [HttpGet]
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
    /// GET /api/v2/products/{id}
    /// </summary>
    [HttpGet("{id:int}")]
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
