using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class TrendingToken
{
    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("decimals")]
    public int Decimals { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }
}