using System.Text.Json.Serialization;

namespace SolScanner;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ETokenType
{
    token, nft
}