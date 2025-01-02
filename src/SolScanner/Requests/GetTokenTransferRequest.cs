namespace SolScanner.Requests;

public sealed class GetTokenTransferRequest : BaseRequest
{
    /// <summary>
    /// A token address on solana blockchain
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Type of transfer data
    /// </summary>
    public EActivityType ActivityType { get; set; }
    
    /// <summary>
    /// Filter transfer data with direction is from an address
    /// </summary>
    public string From { get; set; }
    
    /// <summary>
    /// Filter transfer data with direction is to an address
    /// </summary>
    public string To { get; set; }

    /// <summary>
    /// Filter transfer data by by amount. But you need to pass token address first because amount filter will be belong to one token address. Ex: Filter amount from 1 to 2 SOL
    /// </summary>
    public uint[] Amount { get; set; }

    /// <summary>
    /// Used when you want to filter data by block time. Format time: UnixTime in seconds.
    /// </summary>
    public uint[] BlockTime { get; set; }

    /// <summary>
    /// Exclude transfer that has amount is zero
    /// </summary>
    public bool ExcludeAmountZero { get; set; }
    
    /// <summary>
    /// Page number for pagination
    /// </summary>
    public uint Page { get; set; }
    
    /// <summary>
    /// Number items per page
    /// </summary>
    public uint PageSize { get; set; }

    /// <summary>
    /// The parameter allows you to specify the field by which the returned list will be sorted
    /// </summary>
    public ESortByBlock SortBy { get; set; }

    /// <summary>
    /// The parameter allows you to specify the sort order
    /// </summary>
    public ESortOrder SortOrder { get; set; }
    
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/token/transfer")
            .WithAddress(Address)
            .WithActivityTypes(ActivityType)
            .WithFrom(From)
            .WithTo(To)
            .WithAmounts(Amount)
            .WithBlockTimes(BlockTime)
            .ExcludeAmountZero(ExcludeAmountZero)
            .WithPage(Page)
            .WithPageSize(PageSize)
            .WithSortBy(SortBy)
            .WithSortOrder(SortOrder)
            .Build();
    }
}