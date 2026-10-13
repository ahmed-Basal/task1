namespace ApiVersioningDemo.Models.V2;

/// <summary>
/// Generic API response envelope used across Version 2 endpoints.
/// </summary>
/// <typeparam name="T">The type of the payload data returned.</typeparam>
public class ApiResponseV2<T>
{
    /// <summary>
    /// Indicates whether the request succeeded.
    /// </summary>
    /// <example>true</example>
    public bool Success { get; set; } = true;

    /// <summary>
    /// The API version that handled the request.
    /// </summary>
    /// <example>2.0</example>
    public string ApiVersion { get; set; } = "2.0";

    /// <summary>
    /// Descriptive status message or error information.
    /// </summary>
    /// <example>Products retrieved successfully in V2 format.</example>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Total number of items in the response payload.
    /// </summary>
    /// <example>4</example>
    public int TotalCount { get; set; }

    /// <summary>
    /// The actual response payload data.
    /// </summary>
    public T? Data { get; set; }
}
