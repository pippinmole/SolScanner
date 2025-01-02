using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SolScanner.Responses;

public sealed class NftNews
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

    [JsonPropertyName("info")]
    public Info Info { get; set; }
}

public sealed class Info
{
    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("collection")]
    public string Collection { get; set; }

    [JsonPropertyName("collectionId")]
    public string CollectionId { get; set; }

    [JsonPropertyName("collectionKey")]
    public string CollectionKey { get; set; }

    [JsonPropertyName("createdTime")]
    public int CreatedTime { get; set; }

    [JsonPropertyName("data")]
    public InfoData Data { get; set; }

    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }

    [JsonPropertyName("mintTx")]
    public string MintTx { get; set; }
}

public sealed class InfoData
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

public sealed class Attribute
{
    [JsonPropertyName("trait_type")]
    public string TraitType { get; set; }

    [JsonPropertyName("value")]
    public object Value { get; set; }
}

public sealed class Creator
{
    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("verified")]
    public int Verified { get; set; }

    [JsonPropertyName("share")]
    public int Share { get; set; }
}

public sealed class Meta
{
    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("tokenId")]
    public int TokenId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("seller_fee_basis_points")]
    public int SellerFeeBasisPoints { get; set; }

    [JsonPropertyName("edition")]
    public int Edition { get; set; }

    [JsonPropertyName("attributes")]
    public List<Attribute> Attributes { get; set; }

    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }

    [JsonPropertyName("retried")]
    public int Retried { get; set; }
}

public sealed class Properties
{
    [JsonPropertyName("files")]
    public List<File> Files { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; }
}

public sealed class File
{
    [JsonPropertyName("uri")]
    public string Uri { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}