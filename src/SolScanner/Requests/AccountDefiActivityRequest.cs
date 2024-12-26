namespace SolScanner.Requests;

public sealed class AccountDefiActivityRequest : BaseRequest
{
    public string address { get; set; }
    public EActivityType[] activityTypes { get; set; }
    public string from { get; set; }
    public string[] platform { get; set; }
    public string[] sources { get; set; }
    public string token { get; set; }
    public uint[] blockTimes { get; set; }
    public uint page { get; set; }
    public uint pageSize { get; set; }
    public string sortBy { get; set; }
    public string sortOrder { get; set; }
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/account/defi/activities")
            .WithAddress(address)
            .WithActivityTypes(activityTypes)
            .WithFrom(from)
            .WithPlatforms(platform)
            .WithSourceAddresses(sources)
            .WithToken(token)
            .WithBlockTimes(blockTimes)
            .WithPage(page)
            .WithPageSize(pageSize)
            .WithSortBy(sortBy)
            .WithSortOrder(sortOrder)
            .Build();
    }
}