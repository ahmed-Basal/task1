using ApiVersioningDemo;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers
builder.Services.AddControllers();

// Configure API Versioning
builder.Services.AddApiVersioning(options =>
{
    // Default version is 1.0
    options.DefaultApiVersion = new ApiVersion(1, 0);
    // If client does not specify version, assume default
    options.AssumeDefaultVersionWhenUnspecified = true;
    // Advertise supported versions in response headers
    options.ReportApiVersions = true;
    // Read version from URL path, query string, or header
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version")
    );
})
.AddMvc()
.AddApiExplorer(options =>
{
    // Format version as 'v'major[.minor], e.g. v1, v2
    options.GroupNameFormat = "'v'VVV";
    // Substitute {version:apiVersion} in route templates
    options.SubstituteApiVersionInUrl = true;
});

// Swagger documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                $"Products API - {description.GroupName.ToUpperInvariant()}"
            );
        }
    });

    // Scalar API Reference (modern OpenAPI documentation UI)
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Products API - Scalar Documentation")
               .WithTheme(ScalarTheme.Moon)
               .WithOpenApiRoutePattern("/swagger/{documentName}/swagger.json");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
