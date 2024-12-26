using System;
using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class BlockDetailsResponse
{
    [JsonPropertyName("blockhash")]
    public string Blockhash { get; set; }

    [JsonPropertyName("fee_rewards")]
    public int FeeRewards { get; set; }

    [JsonPropertyName("transactions_count")]
    public int TransactionsCount { get; set; }

    [JsonPropertyName("block_height")]
    public int BlockHeight { get; set; }

    [JsonPropertyName("block_time")]
    public int BlockTime { get; set; }

    [JsonPropertyName("time")]
    public DateTime Time { get; set; }

    [JsonPropertyName("parent_slot")]
    public int ParentSlot { get; set; }

    [JsonPropertyName("previous_block_hash")]
    public string PreviousBlockHash { get; set; }
}