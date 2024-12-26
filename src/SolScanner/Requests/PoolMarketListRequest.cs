namespace SolScanner.Requests;

public sealed class PoolMarketListRequest : BaseRequest
{
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/market/list")
            .WithSortBy(SortBy)
            .WithSortOrder(SortOrder)
            .WithPage(Page)
            .WithPageSize(PageSize)
            .WithProgramAddress(ProgramAddress)
            .Build();
    }

    /// <summary>
    /// Program owner address
    /// </summary>
    public string ProgramAddress { get; set; }

    /// <summary>
    /// Number items per page
    /// </summary>
    public uint PageSize { get; set; }

    /// <summary>
    /// Page number for pagination
    /// </summary>
    public uint Page { get; set; }

    /// <summary>
    /// The parameter allows you to specify the sort order
    /// </summary>
    public string SortOrder { get; set; }

    /// <summary>
    /// The parameter allows you to specify the field by which the returned list of pools will be sorted. Enum: created_time
    /// </summary>
    public string SortBy { get; set; }
}