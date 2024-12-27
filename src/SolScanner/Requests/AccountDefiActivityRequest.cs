namespace SolScanner.Requests;

public sealed class AccountDefiActivityRequest : BaseRequest
{
    public string Address { get; set; }
    public EDefiActivityType[] ActivityTypes { get; set; }
    public string From { get; set; }
    public string[] Platform { get; set; }
    public string[] Sources { get; set; }
    public string Token { get; set; }
    public uint[] BlockTimes { get; set; }
    public uint Page { get; set; }
    public uint PageSize { get; set; }
    public string SortBy { get; set; }
    public string SortOrder { get; set; }

    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/account/defi/activities")
            .WithAddress(Address)
            .WithActivityTypes(ActivityTypes)
            .WithFrom(From)
            .WithPlatforms(Platform)
            .WithSourceAddresses(Sources)
            .WithToken(Token)
            .WithBlockTimes(BlockTimes)
            .WithPage(Page)
            .WithPageSize(PageSize)
            .WithSortBy(SortBy)
            .WithSortOrder(SortOrder)
            .Build();
    }
}