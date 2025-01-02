using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class TopToken
{
    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("decimals")]
    public int Decimals { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("market_cap")]
    public long MarketCap { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("price_24h_change")]
    public double Price24hChange { get; set; }

    [JsonPropertyName("created_time")]
    public int CreatedTime { get; set; }
}