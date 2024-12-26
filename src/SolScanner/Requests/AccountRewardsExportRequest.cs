namespace SolScanner.Requests;

public sealed class AccountRewardsExportRequest : BaseRequest
{
    public string Address { get; set; }
    public uint TimeFrom { get; set; }
    public uint TimeTo { get; set; }
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/account/reward/export")
            .WithAddress(Address)
            .WithTimeFrom(TimeFrom)
            .WithTimeTo(TimeTo)
            .Build();
    }
}