namespace SolScanner.Requests;

public sealed class AccountBalanceChangeActivitiesRequest : BaseRequest
{
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/account/balance_change")
            .WithAddress(Address)
            .WithToken(Token)
            .WithBlockTimes(BlockTimes)
            .WithPageSize(PageSize)
            .WithPage(Page)
            .WithRemoveSpam(RemoveSpam)
            .WithAmounts(Amounts)
            .WithFlow(Flow)
            .WithSortBy(SortBy)
            .WithSortOrder(SortOrder)
            .Build();
    }

    /// <summary>
    /// The parameter allows you to specify the sort order
    /// </summary>
    public string SortOrder { get; set; }

    /// <summary>
    /// The parameter allows you to specify the field by which the returned list will be sorted
    /// </summary>
    public string SortBy { get; set; }

    /// <summary>
    /// Filter by change direction: in or out
    /// </summary>
    public string Flow { get; set; }

    /// <summary>
    /// Filter by amount range for a specific token. Example: [1, So11111111111111111111111111111111111111112]
    /// </summary>
    public uint[] Amounts { get; set; }

    /// <summary>
    /// A Wallet address on solana blockchain
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Filter activities data by token address
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Used when you want to filter data by block time. Format time: UnixTime in seconds. You need to pass array into http query to filter by start and stop block_time. 
    /// </summary>
    public uint[] BlockTimes { get; set; }

    /// <summary>
    /// Number items per page. Valid values: 10, 20, 30, 40, 60, 100
    /// </summary>
    public uint PageSize { get; set; }

    /// <summary>
    /// Page number for pagination
    /// </summary>
    public uint Page { get; set; }

    /// <summary>
    /// The query parameter to determine if spam activities have been removed or not
    /// </summary>
    public bool RemoveSpam { get; set; }
}