namespace SolScanner.Requests;

public sealed class AccountDetailsRequest : BaseRequest
{
    /// <summary>
    /// A wallet address on solana blockchain
    /// </summary>
    public string Address { get; set; }
    
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/account/detail")
            .WithAddress(Address)
            .Build();
    }
}