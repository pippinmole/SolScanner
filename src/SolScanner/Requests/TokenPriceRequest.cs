using System;

namespace SolScanner.Requests;

public sealed class TokenPriceRequest : BaseRequest
{
    /// <summary>
    /// A token address on solana blockchain
    /// </summary>
    public string Address { get; set; }
    
    /// <summary>
    /// Used when you want to filter data by time.
    /// </summary>
    public DateTime[] Times { get; set; }

    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/token/price")
            .WithAddress(Address)
            .WithTimes(Times)
            .Build();
    }
}