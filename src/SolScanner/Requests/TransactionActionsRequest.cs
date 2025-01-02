namespace SolScanner.Requests;

public sealed class TransactionActionsRequest : BaseRequest
{
    /// <summary>
    /// Transaction Address
    /// </summary>
    public string Tx { get; set; }

    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/transaction/actions")
            .WithTx(Tx)
            .Build();
    }
}