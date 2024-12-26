namespace SolScanner.Requests;

public sealed class TransactionDetailsRequest : BaseRequest
{
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/transaction/detail")
            .WithTx(Tx)
            .Build();
    }

    /// <summary>
    /// Transaction Address
    /// </summary>
    public string Tx { get; set; }
}