using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class AccountTransaction
{
    [JsonPropertyName("slot")]
    public int Slot { get; set; }

    [JsonPropertyName("fee")]
    public int Fee { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("signer")]
    public List<string> Signer { get; set; }

    [JsonPropertyName("block_time")]
    public int BlockTime { get; set; }

    [JsonPropertyName("tx_hash")]
    public string TxHash { get; set; }

    [JsonPropertyName("parsed_instructions")]
    public List<ParsedInstruction> ParsedInstructions { get; set; }

    [JsonPropertyName("program_ids")]
    public List<string> ProgramIds { get; set; }

    [JsonPropertyName("time")]
    public DateTime Time { get; set; }
}