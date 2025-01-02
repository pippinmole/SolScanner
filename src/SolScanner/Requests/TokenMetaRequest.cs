using SolScanner.Requests;

namespace SolScanner;

public sealed class TokenMetaRequest : BaseRequest
{
    /// <summary>
    /// A token address on solana blockchain
    /// </summary>
    public string Address { get; set; }
    
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/token/meta")
            .WithAddress(Address)
            .Build();
    }
}