using SolScanner.Requests;

namespace SolScanner;

public sealed class BlockDetailsRequest : BaseRequest
{
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/block/detail")
            .WithBlock(BlockNumber)
            .Build();
    }

    /// <summary>
    /// The slot index of a block
    /// </summary>
    public uint BlockNumber { get; set; }
}