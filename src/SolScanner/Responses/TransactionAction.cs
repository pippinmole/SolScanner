using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class TransactionAction
{
    [JsonPropertyName("tx_hash")]
    public string TxHash { get; set; }

    [JsonPropertyName("block_id")]
    public int BlockId { get; set; }

    [JsonPropertyName("block_time")]
    public int BlockTime { get; set; }

    [JsonPropertyName("time")]
    public DateTime Time { get; set; }

    [JsonPropertyName("fee")]
    public int Fee { get; set; }

    [JsonPropertyName("transfers")]
    public List<ActionTransfer> Transfers { get; set; }

    [JsonPropertyName("activities")]
    public List<ActionActivity> Activities { get; set; }

    [JsonPropertyName("amm_id")]
    public string AmmId { get; set; }

    [JsonPropertyName("amm_authority")]
    public object AmmAuthority { get; set; }

    [JsonPropertyName("account")]
    public string Account { get; set; }

    [JsonPropertyName("token_1")]
    public string Token1 { get; set; }

    [JsonPropertyName("token_2")]
    public string Token2 { get; set; }

    [JsonPropertyName("amount_1")]
    public int Amount1 { get; set; }

    [JsonPropertyName("amount_1_str")]
    public string Amount1Str { get; set; }

    [JsonPropertyName("amount_2")]
    public int Amount2 { get; set; }

    [JsonPropertyName("amount_2_str")]
    public string Amount2Str { get; set; }

    [JsonPropertyName("token_decimal_1")]
    public int TokenDecimal1 { get; set; }

    [JsonPropertyName("token_decimal_2")]
    public int TokenDecimal2 { get; set; }

    [JsonPropertyName("token_account_1_1")]
    public string TokenAccount11 { get; set; }

    [JsonPropertyName("token_account_1_2")]
    public string TokenAccount12 { get; set; }

    [JsonPropertyName("token_account_2_1")]
    public string TokenAccount21 { get; set; }

    [JsonPropertyName("token_account_2_2")]
    public string TokenAccount22 { get; set; }

    [JsonPropertyName("owner_1")]
    public string Owner1 { get; set; }

    [JsonPropertyName("owner_2")]
    public string Owner2 { get; set; }
}

public sealed class ActionTransfer
{
    [JsonPropertyName("source_owner")]
    public string SourceOwner { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("destination")]
    public string Destination { get; set; }

    [JsonPropertyName("destination_owner")]
    public string DestinationOwner { get; set; }

    [JsonPropertyName("transfer_type")]
    public string TransferType { get; set; }

    [JsonPropertyName("token_address")]
    public string TokenAddress { get; set; }

    [JsonPropertyName("decimals")]
    public int Decimals { get; set; }

    [JsonPropertyName("amount_str")]
    public string AmountStr { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    [JsonPropertyName("program_id")]
    public string ProgramId { get; set; }

    [JsonPropertyName("outer_program_id")]
    public string OuterProgramId { get; set; }

    [JsonPropertyName("ins_index")]
    public int InsIndex { get; set; }

    [JsonPropertyName("outer_ins_index")]
    public int OuterInsIndex { get; set; }
}

public sealed class ActionActivity
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("activity_type")]
    public string ActivityType { get; set; }

    [JsonPropertyName("program_id")]
    public string ProgramId { get; set; }

    [JsonPropertyName("data")]
    public ActivityData Data { get; set; }

    [JsonPropertyName("ins_index")]
    public int InsIndex { get; set; }

    [JsonPropertyName("outer_ins_index")]
    public int OuterInsIndex { get; set; }

    [JsonPropertyName("outer_program_id")]
    public string OuterProgramId { get; set; }
}

public sealed class ActivityData
{
    [JsonPropertyName("amm_id")]
    public string AmmId { get; set; }

    [JsonPropertyName("amm_authority")]
    public object AmmAuthority { get; set; }

    [JsonPropertyName("account")]
    public string Account { get; set; }

    [JsonPropertyName("token_1")]
    public string Token1 { get; set; }

    [JsonPropertyName("token_2")]
    public string Token2 { get; set; }

    [JsonPropertyName("amount_1")]
    public int Amount1 { get; set; }

    [JsonPropertyName("amount_1_str")]
    public string Amount1Str { get; set; }

    [JsonPropertyName("amount_2")]
    public int Amount2 { get; set; }

    [JsonPropertyName("amount_2_str")]
    public string Amount2Str { get; set; }

    [JsonPropertyName("token_decimal_1")]
    public int TokenDecimal1 { get; set; }

    [JsonPropertyName("token_decimal_2")]
    public int TokenDecimal2 { get; set; }

    [JsonPropertyName("token_account_1_1")]
    public string TokenAccount11 { get; set; }

    [JsonPropertyName("token_account_1_2")]
    public string TokenAccount12 { get; set; }

    [JsonPropertyName("token_account_2_1")]
    public string TokenAccount21 { get; set; }

    [JsonPropertyName("token_account_2_2")]
    public string TokenAccount22 { get; set; }

    [JsonPropertyName("owner_1")]
    public string Owner1 { get; set; }

    [JsonPropertyName("owner_2")]
    public string Owner2 { get; set; }
}