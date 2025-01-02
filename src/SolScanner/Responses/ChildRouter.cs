using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class ChildRouter
{
    [JsonPropertyName("token1")]
    public string Token1 { get; set; }

    [JsonPropertyName("token1_decimals")]
    public int Token1Decimals { get; set; }

    [JsonPropertyName("amount1")]
    public string Amount1 { get; set; }

    [JsonPropertyName("token2")]
    public string Token2 { get; set; }

    [JsonPropertyName("token2_decimals")]
    public int Token2Decimals { get; set; }

    [JsonPropertyName("amount2")]
    public string Amount2 { get; set; }
}