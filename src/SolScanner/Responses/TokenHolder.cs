using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class TokenHolder
{
    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("amount")]
    public long Amount { get; set; }

    [JsonPropertyName("decimals")]
    public int Decimals { get; set; }

    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    [JsonPropertyName("rank")]
    public int Rank { get; set; }
}