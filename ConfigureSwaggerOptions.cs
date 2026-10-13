using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiVersioningDemo;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
    }

    private static Microsoft.OpenApi.OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new Microsoft.OpenApi.OpenApiInfo
        {
            Title = "Products API",
            Version = description.ApiVersion.ToString(),
            Description = description.IsDeprecated
                ? "This API version has been deprecated."
                : $"API Version {description.ApiVersion} - Implementation of API Versioning in ASP.NET Core"
        };

        return info;
    }
}
