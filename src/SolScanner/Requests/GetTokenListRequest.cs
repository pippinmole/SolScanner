namespace SolScanner.Requests;

public sealed class GetTokenListRequest : BaseRequest
{
    public ESortByToken SortBy { get; set; }
    public ESortOrder SortOrder { get; set; }
    public uint Page { get; set; }
    public uint PageSize { get; set; }
    
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/token/list")
            .WithSortBy(SortBy)
            .WithSortOrder(SortOrder)
            .WithPage(Page)
            .WithPageSize(PageSize)
            .Build();
    }
}