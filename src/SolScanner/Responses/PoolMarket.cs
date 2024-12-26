using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class PoolMarket
{
    [JsonPropertyName("pool_address")]
    public string PoolAddress { get; set; }

    [JsonPropertyName("program_id")]
    public string ProgramId { get; set; }

    [JsonPropertyName("token1")]
    public string Token1 { get; set; }

    [JsonPropertyName("token1_account")]
    public string Token1Account { get; set; }

    [JsonPropertyName("token2")]
    public string Token2 { get; set; }

    [JsonPropertyName("token2_account")]
    public string Token2Account { get; set; }

    [JsonPropertyName("total_volume_24h")]
    public int TotalVolume24h { get; set; }

    [JsonPropertyName("total_trade_24h")]
    public int TotalTrade24h { get; set; }

    [JsonPropertyName("created_time")]
    public int CreatedTime { get; set; }
}