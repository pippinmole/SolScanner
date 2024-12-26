using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class SolscanResponse<T> where T : class
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    
    [JsonPropertyName("data")]
    public T Data { get; set; }
}