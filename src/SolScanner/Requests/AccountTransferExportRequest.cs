namespace SolScanner.Requests;

public sealed class AccountTransferExportRequest : BaseRequest
{
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/account/transfer/export")
            .WithAddress(Address)
            .WithActivityTypes(ActivityTypes)
            .WithTokenAccount(TokenAccount)
            .WithFrom(From)
            .WithTo(To)
            .WithToken(Token)
            .WithAmounts(Amounts)
            .WithBlockTimes(BlockTimes)
            .ExcludeAmountZero(ExcludeAmountZero)
            .WithFlow(Flow)
            .Build();
    }

    /// <summary>
    /// Filter by transfer direction: in or out
    /// </summary>
    public string Flow { get; set; }

    /// <summary>
    /// Exclude transfers with zero amount
    /// </summary>
    public bool ExcludeAmountZero { get; set; }

    /// <summary>
    /// Filter by block time range (Unix timestamp in seconds). Example: ?block_time[]=1720153259&block_time[]=1720153276
    /// </summary>
    public uint[] BlockTimes { get; set; }

    /// <summary>
    /// Filter by amount range for a specific token. Example: ?amount[]=1&amount[]=2&token=So11111111111111111111111111111111111111112
    /// </summary>
    public uint[] Amounts { get; set; }

    /// <summary>
    /// Filter by token address. For native SOL transfers, use So11111111111111111111111111111111111111111
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Filter transfers from a specific address
    /// </summary>
    public string To { get; set; }

    /// <summary>
    /// Filter transfer data with direction is from an address
    /// </summary>
    public string From { get; set; }

    /// <summary>
    /// Filter transfers for a specific token account in the wallet
    /// </summary>
    public string TokenAccount { get; set; }

    /// <summary>
    /// Type of transfer
    /// </summary>
    public EActivityType[] ActivityTypes { get; set; }

    /// <summary>
    /// Solana wallet address
    /// </summary>
    public string Address { get; set; }
}