namespace SolScanner.Requests;

public sealed class TokenDefiActivitiesRequest : BaseRequest
{
    public string Address { get; set; }
    public string From { get; set; }
    public string[] Platforms { get; set; }
    public string[] Sources { get; set; }
    public EDefiActivityType[] ActivityTypes { get; set; }
    public string Token { get; set; }
    public uint[] BlockTimes { get; set; }
    public uint Page { get; set; }
    public uint PageSize { get; set; }
    public ESortByBlock SortBy { get; set; }
    public ESortOrder SortOrder { get; set; }


    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/token/defi/activities")
            .WithAddress(Address)
            .WithFrom(From)
            .WithPlatforms(Platforms)
            .WithSourceAddresses(Sources)
            .WithActivityTypes(ActivityTypes)
            .WithToken(Token)
            .WithBlockTimes(BlockTimes)
            .WithPage(Page)
            .WithPageSize(PageSize)
            .WithSortBy(SortBy)
            .WithSortOrder(SortOrder)
            .Build();
    }
}