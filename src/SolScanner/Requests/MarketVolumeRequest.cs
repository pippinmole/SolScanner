using System;

namespace SolScanner.Requests;

public sealed class MarketVolumeRequest : BaseRequest
{
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/market/volume")
            .WithAddress(Address)
            .WithTimes(Times)
            .Build();
    }

    /// <summary>
    /// Used when you want to filter data by time.
    /// </summary>
    public DateTime[] Times { get; set; }

    /// <summary>
    /// Market Id
    /// </summary>
    public string Address { get; set; }
}