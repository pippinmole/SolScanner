namespace SolScanner.Requests;

public sealed class AccountStakesRequest : BaseRequest
{
    /// <summary>
    /// A wallet address on solana blockchain
    /// </summary>
    public string Address { get; set; }
    
    /// <summary>
    /// Page number for pagination
    /// </summary>
    public uint Page { get; set; }
    
    /// <summary>
    /// The number of items per page
    /// </summary>
    public uint PageSize { get; set; }
    
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithAddress(Address)
            .WithPage(Page)
            .WithPageSize(PageSize)
            .Build();
    }
}