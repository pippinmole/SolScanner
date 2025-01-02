using SolScanner.Requests;

namespace SolScanner;

public sealed class TokenMarketsRequest : BaseRequest
{
    public string Token { get; set; }
    public string SortBy { get; set; }
    public string Program { get; set; }
    public uint Page { get; set; }
    public uint PageSize { get; set; }
    
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/token/markets")
            .WithToken(Token)
            .WithSortBy(SortBy)
            .WithProgramAddress(Program)
            .WithPage(Page)
            .WithPageSize(PageSize)
            .Build();
    }
}