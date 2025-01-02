using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class TokenPrice
{
    [JsonPropertyName("date")]
    public int Date { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }
}