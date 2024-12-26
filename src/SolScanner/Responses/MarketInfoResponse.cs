using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class MarketInfoResponse
{
    [JsonPropertyName("pool_address")]
    public string PoolAddress { get; set; }

    [JsonPropertyName("program_id")]
    public string ProgramId { get; set; }

    [JsonPropertyName("token1")]
    public string Token1 { get; set; }

    [JsonPropertyName("token2")]
    public string Token2 { get; set; }

    [JsonPropertyName("token1_account")]
    public string Token1Account { get; set; }

    [JsonPropertyName("token2_account")]
    public string Token2Account { get; set; }

    [JsonPropertyName("token1_amount")]
    public double Token1Amount { get; set; }

    [JsonPropertyName("token2_amount")]
    public double Token2Amount { get; set; }
}