using System.Text.Json.Serialization;

namespace SolScanner;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EFlow
{
    In, 
    Out
}