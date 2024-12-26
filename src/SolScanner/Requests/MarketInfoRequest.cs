namespace SolScanner.Requests;

public sealed class MarketInfoRequest : BaseRequest
{
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/market/info")
            .WithAddress(Address)
            .Build();
    }

    /// <summary>
    /// Market Id
    /// </summary>
    public string Address { get; set; }
}