namespace SolScanner.Requests;

public sealed class NftCollectionRequest : BaseRequest
{
    /// <summary>
    /// Days range. Valid values: 1, 7, 30
    /// </summary>
    public uint Range { get; set; }

    /// <summary>
    /// The parameter allows you to specify the sort order
    /// </summary>
    public ESortOrder SortOrder { get; set; }
    public ENftSortBy SortBy { get; set; }
    public uint Page { get; set; }
    public uint PageSize { get; set; }
    public string Collection { get; set; }

    
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/nft/collection/lists")
            .WithRange(Range)
            .WithSortOrder(SortOrder)
            .WithSortBy(SortBy)
            .WithPage(Page)
            .WithPageSize(PageSize)
            .WithCollection(Collection)
            .Build();
    }
}

public enum ENftSortBy
{
    Items,
    FloorPrice,
    Volumes
}