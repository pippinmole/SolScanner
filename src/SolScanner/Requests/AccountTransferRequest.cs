namespace SolScanner.Requests;

public sealed class AccountTransferRequest : BaseRequest
{
    /// <summary>
    /// Solana wallet address
    /// </summary>
    public string Address { get; set; }
    
    /// <summary>
    /// Type of transfer <see cref="EActivityType"/>
    /// </summary>
    public EActivityType[] ActivityTypes { get; set; }
    
    /// <summary>
    /// Filter transfers for a specific token account in the wallet
    /// </summary>
    public string TokenAccount { get; set; }
    
    /// <summary>
    /// Filter transfer data with direction is from an address
    /// </summary>
    public string From { get; set; }
    
    /// <summary>
    /// Filter transfers from a specific address
    /// </summary>
    public string To { get; set; }
    
    /// <summary>
    /// Filter by token address. For native SOL transfers, use So11111111111111111111111111111111111111111
    /// </summary>
    public string Token { get; set; }
    
    /// <summary>
    /// Filter by amount range for a specific token. Example: ?amount[]=1&amount[]=2&token=So11111111111111111111111111111111111111112
    /// </summary>
    public uint[] Amount { get; set; }
    
    /// <summary>
    /// Filter by block time range (Unix timestamp in seconds). Example: ?block_time[]=1720153259&block_time[]=1720153276
    /// </summary>
    public uint[] BlockTime { get; set; }
    
    /// <summary>
    /// Exclude transfers with zero amount
    /// </summary>
    public bool ExcludeAmountZero { get; set; }
    
    /// <summary>
    /// Filter by transfer direction: in or out. <see cref="EFlow"/>
    /// </summary>
    public string Flow { get; set; }
    
    /// <summary>
    /// Page number for pagination
    /// </summary>
    public uint Page { get; set; }
    
    /// <summary>
    /// Number of items per page
    /// </summary>
    public uint PageSize { get; set; }
    
    /// <summary>
    /// The parameter allows you to specify the field by which the returned list will be sorted
    /// </summary>
    public string SortOrder { get; set; }
    
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/account/transfer")
            .WithAddress(Address)
            .WithActivityTypes(ActivityTypes)
            .WithTokenAccount(TokenAccount)
            .WithFrom(From)
            .WithTo(To)
            .WithToken(Token)
            .WithAmounts(Amount)
            .WithBlockTimes(BlockTime)
            .ExcludeAmountZero(ExcludeAmountZero)
            .WithFlow(Flow)
            .WithPage(Page)
            .WithPageSize(PageSize)
            .WithSortOrder(SortOrder)
            .Build();
    }
}