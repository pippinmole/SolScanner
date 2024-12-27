namespace SolScanner.Requests;

public sealed class AccountTokenAccountsRequest : BaseRequest
{
    public string Address { get; set; }
    public ETokenType TokenType { get; set; }
    public uint Page { get; set; }
    public uint PageSize { get; set; }
    public bool HideZero { get; set; }

    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/account/token-accounts")
            .WithAddress(Address)
            .WithTokenType(TokenType)
            .WithPage(Page)
            .WithPageSize(PageSize)
            .WithHideZero(HideZero)
            .Build();
    }
}