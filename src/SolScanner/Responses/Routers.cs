using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class Routers
{
    [JsonPropertyName("token1")]
    public string Token1 { get; set; }

    [JsonPropertyName("token1_decimals")]
    public int Token1Decimals { get; set; }

    [JsonPropertyName("amount1")]
    public int Amount1 { get; set; }

    [JsonPropertyName("token2")]
    public string Token2 { get; set; }

    [JsonPropertyName("token2_decimals")]
    public int Token2Decimals { get; set; }

    [JsonPropertyName("amount2")]
    public long Amount2 { get; set; }

    [JsonPropertyName("child_routers")]
    public List<ChildRouter> ChildRouters { get; set; }
}