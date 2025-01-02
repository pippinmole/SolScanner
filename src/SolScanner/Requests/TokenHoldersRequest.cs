namespace SolScanner.Requests;

public class TokenHoldersRequest : BaseRequest
{
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/token/holders")
            .WithAddress(Address)
            .WithPage(Page)
            .WithPageSize(PageSize)
            .WithFromAmount(FromAmount)
            .WithToAmount(ToAmount)
            .Build();
    }
    
    /// <summary>
    /// A token address on solana blockchain
    /// </summary>
    public string Address { get; set; }
    
    /// <summary>
    /// Page number for pagination
    /// </summary>
    public uint Page { get; set; }
    
    /// <summary>
    /// Number items per page. Valid values are: 10, 20, 30, 40
    /// </summary>
    public uint PageSize { get; set; }
    
    /// <summary>
    /// Filter holders by minimum token holding amount.
    /// </summary>
    public uint FromAmount { get; set; }
    
    /// <summary>
    /// Filter holders by maximum token holding amount.
    /// </summary>
    public uint ToAmount { get; set; }
}