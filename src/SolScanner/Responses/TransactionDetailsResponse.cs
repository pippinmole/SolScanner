using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class SolanaBalanceChange
{
    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("pre_balance")]
    public string PreBalance { get; set; }

    [JsonPropertyName("post_balance")]
    public string PostBalance { get; set; }

    [JsonPropertyName("change_amount")]
    public string ChangeAmount { get; set; }
}

public sealed class AccountKey
{
    [JsonPropertyName("pubkey")]
    public string Pubkey { get; set; }

    [JsonPropertyName("signer")]
    public bool Signer { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("writable")]
    public bool Writable { get; set; }
}

public sealed class TransactionDetailsResponse
{
    [JsonPropertyName("block_id")]
    public int BlockId { get; set; }

    [JsonPropertyName("fee")]
    public int Fee { get; set; }

    [JsonPropertyName("reward")]
    public List<object> Reward { get; set; }

    [JsonPropertyName("sol_bal_change")]
    public List<SolanaBalanceChange> SolBalChange { get; set; }

    [JsonPropertyName("token_bal_change")]
    public List<object> TokenBalChange { get; set; }

    [JsonPropertyName("tokens_involved")]
    public List<object> TokensInvolved { get; set; }

    [JsonPropertyName("parsed_instructions")]
    public List<ParsedInstructionFull> ParsedInstructions { get; set; }

    [JsonPropertyName("programs_involved")]
    public List<string> ProgramsInvolved { get; set; }

    [JsonPropertyName("signer")]
    public List<string> Signer { get; set; }

    [JsonPropertyName("list_signer")]
    public List<string> ListSigner { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("account_keys")]
    public List<AccountKey> AccountKeys { get; set; }

    [JsonPropertyName("compute_units_consumed")]
    public int ComputeUnitsConsumed { get; set; }

    [JsonPropertyName("confirmations")]
    public object Confirmations { get; set; }

    [JsonPropertyName("version")]
    public int Version { get; set; }

    [JsonPropertyName("tx_hash")]
    public string TxHash { get; set; }

    [JsonPropertyName("block_time")]
    public int BlockTime { get; set; }

    [JsonPropertyName("address_table_lookup")]
    public List<object> AddressTableLookup { get; set; }

    [JsonPropertyName("log_message")]
    public List<string> LogMessage { get; set; }

    [JsonPropertyName("recent_block_hash")]
    public string RecentBlockHash { get; set; }

    [JsonPropertyName("tx_status")]
    public string TxStatus { get; set; }
}

public sealed class ParsedInstructionFull
{
    [JsonPropertyName("ins_index")]
    public int InsIndex { get; set; }
    
    [JsonPropertyName("parsed_type")]
    public string ParsedType { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    [JsonPropertyName("program_id")]
    public string ProgramId { get; set; }
    
    [JsonPropertyName("program")]
    public string Program { get; set; }
    
    [JsonPropertyName("outer_program_id")]
    public string OuterProgramId { get; set; }
    
    [JsonPropertyName("outer_ins_index")]
    public int OuterInsIndex { get; set; }
    
    [JsonPropertyName("data_raw")]
    public DataRaw DataRaw { get; set; }

    [JsonPropertyName("accounts")]
    public List<string> Accounts { get; set; }

    [JsonPropertyName("activities")]
    public List<string> Activities { get; set; }

    [JsonPropertyName("transfers")]
    public List<TransferFull> Transfers { get; set; }

    [JsonPropertyName("program_invoke_level")]
    public int ProgramInvokeLevel { get; set; }
}

public sealed class DataRaw
{
    [JsonPropertyName("info")]
    public DataRawInfo Info { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class DataRawInfo
{
    [JsonPropertyName("destination")]
    public string Destination { get; set; }

    [JsonPropertyName("lamports")]
    public long Lamports { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }
}

public sealed class TransferFull
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
    public long Amount { get; set; }

    [JsonPropertyName("program_id")]
    public string ProgramId { get; set; }

    [JsonPropertyName("outer_program_id")]
    public string OuterProgramId { get; set; }

    [JsonPropertyName("ins_index")]
    public int InsIndex { get; set; }

    [JsonPropertyName("outer_ins_index")]
    public int OuterInsIndex { get; set; }

    [JsonPropertyName("event")]
    public string Event { get; set; }

    // The fee property in this example is just an empty object, so you can map it as 'object'
    // or replace with a more specific type if you need further deserialization.
    [JsonPropertyName("fee")]
    public object Fee { get; set; }
}