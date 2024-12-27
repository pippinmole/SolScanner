using System;
using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class BalanceChangeActivity
{
    [JsonPropertyName("block_id")]
    public int BlockId { get; set; }

    [JsonPropertyName("block_time")]
    public int BlockTime { get; set; }

    [JsonPropertyName("time")]
    public DateTime Time { get; set; }

    [JsonPropertyName("trans_id")]
    public string TransId { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("token_address")]
    public string TokenAddress { get; set; }

    [JsonPropertyName("token_account")]
    public string TokenAccount { get; set; }

    [JsonPropertyName("token_decimals")]
    public int TokenDecimals { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    [JsonPropertyName("pre_balance")]
    public int PreBalance { get; set; }

    [JsonPropertyName("post_balance")]
    public int PostBalance { get; set; }

    [JsonPropertyName("change_type")]
    public string ChangeType { get; set; }

    [JsonPropertyName("fee")]
    public int Fee { get; set; }
}