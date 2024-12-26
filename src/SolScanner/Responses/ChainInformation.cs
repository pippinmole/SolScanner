using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class ChainInformation
{
    [JsonPropertyName("blockHeight")]
    public int BlockHeight { get; set; }
    
    [JsonPropertyName("currentEpoch")]
    public int CurrentEpoch { get; set; }
    
    [JsonPropertyName("absoluteSlot")]
    public int AbsoluteSlot { get; set; }
    
    [JsonPropertyName("transactionCount")]
    public long TransactionCount { get; set; }
}