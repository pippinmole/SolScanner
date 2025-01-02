using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class TokenMarket
{
    [JsonPropertyName("pool_id")]
    public string PoolId { get; set; }

    [JsonPropertyName("program_id")]
    public string ProgramId { get; set; }

    [JsonPropertyName("token_1")]
    public string Token1 { get; set; }

    [JsonPropertyName("token_2")]
    public string Token2 { get; set; }

    [JsonPropertyName("token_account_1")]
    public string TokenAccount1 { get; set; }

    [JsonPropertyName("token_account_2")]
    public string TokenAccount2 { get; set; }

    [JsonPropertyName("total_trades_24h")]
    public int TotalTrades24h { get; set; }

    [JsonPropertyName("total_trades_prev_24h")]
    public int TotalTradesPrev24h { get; set; }

    [JsonPropertyName("total_volume_24h")]
    public double TotalVolume24h { get; set; }

    [JsonPropertyName("total_volume_prev_24h")]
    public double TotalVolumePrev24h { get; set; }
}