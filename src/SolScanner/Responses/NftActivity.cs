using System;
using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class NftActivity
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

    [JsonPropertyName("marketplace_address")]
    public string MarketplaceAddress { get; set; }

    [JsonPropertyName("collection_address")]
    public string CollectionAddress { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    [JsonPropertyName("price")]
    public int Price { get; set; }

    [JsonPropertyName("currency_token")]
    public string CurrencyToken { get; set; }

    [JsonPropertyName("currency_decimals")]
    public int CurrencyDecimals { get; set; }
}