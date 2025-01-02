using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class NftCollection
{
    [JsonPropertyName("collection_id")]
    public string CollectionId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("floor_price")]
    public double FloorPrice { get; set; }

    [JsonPropertyName("items")]
    public int Items { get; set; }

    [JsonPropertyName("marketplaces")]
    public List<string> Marketplaces { get; set; }

    [JsonPropertyName("volumes")]
    public double Volumes { get; set; }

    [JsonPropertyName("total_vol_prev_24h")]
    public double TotalVolPrev24h { get; set; }
}