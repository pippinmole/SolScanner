using SolScanner.Requests;

namespace SolScanner;

public sealed class NftNewsRequest : BaseRequest
{
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/nft/news")
            .WithFilter(Filter)
            .WithPage(Page)
            .WithPageSize(PageSize)
            .Build();
    }

    /// <summary>
    /// 
    /// </summary>
    public ENftFilter Filter { get; set; }

    public uint Page { get; set; }

    public uint PageSize { get; set; }
}