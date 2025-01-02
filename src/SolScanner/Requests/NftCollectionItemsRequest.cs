namespace SolScanner.Requests;

public sealed class NftCollectionItemsRequest : BaseRequest
{
    public string Collection { get; set; }

    public ENftCollectionSortBy SortBy { get; set; }

    public uint Page { get; set; }

    public uint PageSize { get; set; }

    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/nft/collection/items")
            .WithCollection(Collection)
            .WithSortBy(SortBy)
            .WithPage(Page)
            .WithPageSize(PageSize)
            .Build();
    }
}

public enum ENftCollectionSortBy
{
    LastTrade,
    ListingPrice
}