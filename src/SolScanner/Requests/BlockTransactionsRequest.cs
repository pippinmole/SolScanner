namespace SolScanner.Requests;

public sealed class BlockTransactionsRequest : BaseRequest
{
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/block/transactions")
            .WithBlock(BlockNumber)
            .WithPage(Page)
            .WithPageSize(PageSize)
            .Build();
    }

    /// <summary>
    /// Number of items per page. Enum: 10, 20, 30, 40, 60, 100
    /// </summary>
    public uint PageSize { get; set; }

    /// <summary>
    /// Page number for pagination
    /// </summary>
    public uint Page { get; set; }

    /// <summary>
    /// The slot index of a block
    /// </summary>
    public uint BlockNumber { get; set; }
    
    
}