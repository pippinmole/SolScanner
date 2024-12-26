using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class AccountStake
{
    [JsonPropertyName("amount")]
    public long Amount { get; set; }

    [JsonPropertyName("role")]
    public List<string> Role { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("voter")]
    public string Voter { get; set; }

    [JsonPropertyName("active_stake_amount")]
    public long ActiveStakeAmount { get; set; }

    [JsonPropertyName("delegated_stake_amount")]
    public long DelegatedStakeAmount { get; set; }

    [JsonPropertyName("sol_balance")]
    public long SolBalance { get; set; }

    [JsonPropertyName("total_reward")]
    public string TotalReward { get; set; }

    [JsonPropertyName("stake_account")]
    public string StakeAccount { get; set; }

    [JsonPropertyName("activation_epoch")]
    public int ActivationEpoch { get; set; }

    [JsonPropertyName("stake_type")]
    public int StakeType { get; set; }
}