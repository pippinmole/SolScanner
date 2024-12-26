using System;
using System.Text.Json.Serialization;

namespace SolScanner;

public sealed class Block
{
    [JsonPropertyName("fee_rewards")]
    public int FeeRewards { get; set; }

    [JsonPropertyName("transactions_count")]
    public int TransactionsCount { get; set; }

    [JsonPropertyName("current_slot")]
    public int CurrentSlot { get; set; }

    [JsonPropertyName("block_height")]
    public int BlockHeight { get; set; }

    [JsonPropertyName("block_time")]
    public int BlockTime { get; set; }

    [JsonPropertyName("time")]
    public DateTime Time { get; set; }

    [JsonPropertyName("block_hash")]
    public string BlockHash { get; set; }

    [JsonPropertyName("parent_slot")]
    public int ParentSlot { get; set; }

    [JsonPropertyName("previous_block_hash")]
    public string PreviousBlockHash { get; set; }
}