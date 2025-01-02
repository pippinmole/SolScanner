using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class TokenMetaResponse
{
    [JsonPropertyName("supply")]
    public string Supply { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("decimals")]
    public int Decimals { get; set; }

    [JsonPropertyName("holder")]
    public int Holder { get; set; }

    [JsonPropertyName("creator")]
    public string Creator { get; set; }

    [JsonPropertyName("create_tx")]
    public string CreateTx { get; set; }

    [JsonPropertyName("created_time")]
    public int CreatedTime { get; set; }

    [JsonPropertyName("first_mint_tx")]
    public string FirstMintTx { get; set; }

    [JsonPropertyName("first_mint_time")]
    public int FirstMintTime { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("volume_24h")]
    public long Volume24h { get; set; }

    [JsonPropertyName("market_cap")]
    public int MarketCap { get; set; }

    [JsonPropertyName("market_cap_rank")]
    public int MarketCapRank { get; set; }

    [JsonPropertyName("price_change_24h")]
    public double PriceChange24h { get; set; }
}