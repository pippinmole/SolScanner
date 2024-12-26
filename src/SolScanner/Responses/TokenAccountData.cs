using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class TokenAccountData
{
    [JsonPropertyName("token_account")]
    public string TokenAccount { get; set; }

    [JsonPropertyName("token_address")]
    public string TokenAddress { get; set; }

    [JsonPropertyName("amount")]
    public long Amount { get; set; }

    [JsonPropertyName("token_decimals")]
    public int TokenDecimals { get; set; }

    [JsonPropertyName("owner")]
    public string Owner { get; set; }
}