namespace SolScanner.Requests;

public sealed class AccountTransactionsRequest : BaseRequest
{
    /// <summary>
    /// A wallet address on solana blockchain
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// The signature of the latest transaction of previous page
    /// </summary>
    public string Before { get; set; }

    /// <summary>
    /// The number of transactions should be returned
    /// </summary>
    public ELimit Limit { get; set; }  
    
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/account/transactions")
            .WithAddress(Address)
            .WithBefore(Before)
            .WithLimit(Limit)
            .Build();
    }
}