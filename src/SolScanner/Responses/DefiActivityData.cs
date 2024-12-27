using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class DefiActivityData
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
    public EDefiActivityType ActivityType { get; set; }

    [JsonPropertyName("from_address")]
    public string FromAddress { get; set; }

    [JsonPropertyName("to_address")]
    public string ToAddress { get; set; }

    [JsonPropertyName("sources")]
    public List<string> Sources { get; set; }

    [JsonPropertyName("platform")]
    public string Platform { get; set; }

    [JsonPropertyName("amount_info")]
    public AmountInfo AmountInfo { get; set; }
}