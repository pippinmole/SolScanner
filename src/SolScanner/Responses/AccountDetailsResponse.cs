using System.Numerics;
using System.Text.Json.Serialization;
using SolScanner.Parsers;

namespace SolScanner.Responses;

public sealed class AccountDetailsResponse
{
    [JsonPropertyName("account")]
    public string Account { get; set; }

    [JsonPropertyName("lamports")]
    public int Lamports { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("executable")]
    public bool Executable { get; set; }

    [JsonPropertyName("owner_program")]
    public string OwnerProgram { get; set; }

    [JsonPropertyName("rent_epoch")]
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger RentEpoch { get; set; }

    [JsonPropertyName("is_oncurve")]
    public bool IsOncurve { get; set; }
}