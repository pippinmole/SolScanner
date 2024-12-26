using System;
using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class Transfer
{
    [JsonPropertyName("block_id")]
    public int BlockId { get; set; }

    [JsonPropertyName("trans_id")]
    public string TransId { get; set; }

    [JsonPropertyName("block_time")]
    public int BlockTime { get; set; }

    [JsonPropertyName("time")]
    public DateTime Time { get; set; }

    [JsonPropertyName("activity_type")]
    public string ActivityType { get; set; }

    [JsonPropertyName("from_address")]
    public string FromAddress { get; set; }

    [JsonPropertyName("to_address")]
    public string ToAddress { get; set; }

    [JsonPropertyName("token_address")]
    public string TokenAddress { get; set; }

    [JsonPropertyName("token_decimals")]
    public int TokenDecimals { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    [JsonPropertyName("flow")]
    public EFlow Flow { get; set; }
}