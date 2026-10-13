namespace ApiVersioningDemo.Models.V2;

public class ApiResponseV2<T>
{
    public bool Success { get; set; } = true;
    public string ApiVersion { get; set; } = "2.0";
    public string Message { get; set; } = string.Empty;
    public int TotalCount { get; set; }
    public T? Data { get; set; }
}
