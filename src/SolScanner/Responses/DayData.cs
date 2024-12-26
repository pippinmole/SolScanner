using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class DayData
{
    [JsonPropertyName("day")]
    public int Day { get; set; }

    [JsonPropertyName("value")]
    public int Value { get; set; }
}