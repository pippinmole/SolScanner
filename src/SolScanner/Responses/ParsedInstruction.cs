using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class ParsedInstruction
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("program")]
    public string Program { get; set; }

    [JsonPropertyName("program_id")]
    public string ProgramId { get; set; }
}