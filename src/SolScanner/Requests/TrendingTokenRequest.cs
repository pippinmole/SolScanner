namespace SolScanner.Requests;

public sealed class TrendingTokenRequest : BaseRequest
{
    /// <summary>
    /// Number items should be returned
    /// </summary>
    public uint Limit { get; set; }

    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/token/trending")
            .WithLimit(Limit)
            .Build();
    }
}