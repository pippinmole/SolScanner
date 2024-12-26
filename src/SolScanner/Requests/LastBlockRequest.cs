namespace SolScanner.Requests;

public sealed class LastBlockRequest : BaseRequest
{
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/block/last")
            .WithLimit(Limit)
            .Build();
    }

    /// <summary>
    /// The number of blocks should be returned.
    /// </summary>
    public ELimit Limit { get; set; }
}