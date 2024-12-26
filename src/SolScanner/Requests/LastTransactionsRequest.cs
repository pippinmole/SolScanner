namespace SolScanner.Requests;

public sealed class LastTransactionsRequest : BaseRequest
{
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/transaction/last")
            .WithLimit(Limit)
            .WithFilter(Filter)
            .Build();
    }

    /// <summary>
    /// The filter parameter for excluding vote transactions
    /// </summary>
    public EFilter Filter { get; set; }

    /// <summary>
    /// The number of transactions should be returned. Enum: 10, 20, 30, 40, 60, 100
    /// </summary>
    public ELimit Limit { get; set; }
}