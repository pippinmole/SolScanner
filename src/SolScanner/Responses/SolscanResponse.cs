using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class SolscanResponse<T> where T : class
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    
    [JsonPropertyName("errors")]
    public SolscanError? Error { get; set; } = null;
    
    [JsonPropertyName("data")]
    public T? Data { get; set; }
}

public sealed class SolscanError
{
    [JsonPropertyName("code")]
    public int Code { get; set; }
    
    [JsonPropertyName("message")]
    public string Message { get; set; } = null!;
}