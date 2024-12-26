using System;
using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class BalanceChangeActivity
{
    [JsonPropertyName("block_id")]
    public int block_id { get; set; }

    [JsonPropertyName("block_time")]
    public int block_time { get; set; }

    [JsonPropertyName("time")]
    public DateTime time { get; set; }

    [JsonPropertyName("trans_id")]
    public string trans_id { get; set; }

    [JsonPropertyName("address")]
    public string address { get; set; }

    [JsonPropertyName("token_address")]
    public string token_address { get; set; }

    [JsonPropertyName("token_account")]
    public string token_account { get; set; }

    [JsonPropertyName("token_decimals")]
    public int token_decimals { get; set; }

    [JsonPropertyName("amount")]
    public int amount { get; set; }

    [JsonPropertyName("pre_balance")]
    public int pre_balance { get; set; }

    [JsonPropertyName("post_balance")]
    public int post_balance { get; set; }

    [JsonPropertyName("change_type")]
    public string change_type { get; set; }

    [JsonPropertyName("fee")]
    public int fee { get; set; }
}