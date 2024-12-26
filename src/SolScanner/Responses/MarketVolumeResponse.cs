using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class MarketVolumeResponse
{
    [JsonPropertyName("pool_address")]
    public string PoolAddress { get; set; }

    [JsonPropertyName("program_id")]
    public string ProgramId { get; set; }

    [JsonPropertyName("total_volume_24h")]
    public int TotalVolume24h { get; set; }

    [JsonPropertyName("total_volume_change_24h")]
    public double TotalVolumeChange24h { get; set; }

    [JsonPropertyName("total_trades_24h")]
    public int TotalTrades24h { get; set; }

    [JsonPropertyName("total_trades_change_24h")]
    public double TotalTradesChange24h { get; set; }

    [JsonPropertyName("days")]
    public List<DayData> Days { get; set; }
}