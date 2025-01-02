using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class NftCollectionItem
{
    [JsonPropertyName("tradeInfo")]
    public TradeInfo TradeInfo { get; set; }

    [JsonPropertyName("info")]
    public NftCollectionInfo Info { get; set; }
}

public sealed class NftCollectionInfo
{
    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("token_name")]
    public string TokenName { get; set; }

    [JsonPropertyName("token_symbol")]
    public string TokenSymbol { get; set; }

    [JsonPropertyName("collection_id")]
    public string CollectionId { get; set; }

    [JsonPropertyName("data")]
    public CollectionData Data { get; set; }

    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }

    [JsonPropertyName("mint_tx")]
    public string MintTx { get; set; }

    [JsonPropertyName("created_time")]
    public int CreatedTime { get; set; }
}

public class CollectionData
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("uri")]
    public string Uri { get; set; }

    [JsonPropertyName("sellerFeeBasisPoints")]
    public int SellerFeeBasisPoints { get; set; }

    [JsonPropertyName("creators")]
    public List<Creator> Creators { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }
}

public sealed class TradeInfo
{
    [JsonPropertyName("trade_time")]
    public int TradeTime { get; set; }

    [JsonPropertyName("signature")]
    public string Signature { get; set; }

    [JsonPropertyName("market_id")]
    public string MarketId { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("price")]
    public string Price { get; set; }

    [JsonPropertyName("currency_token")]
    public string CurrencyToken { get; set; }

    [JsonPropertyName("currency_decimals")]
    public int CurrencyDecimals { get; set; }

    [JsonPropertyName("seller")]
    public string Seller { get; set; }

    [JsonPropertyName("buyer")]
    public string Buyer { get; set; }
}