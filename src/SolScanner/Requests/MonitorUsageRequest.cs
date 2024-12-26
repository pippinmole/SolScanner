namespace SolScanner.Requests;

public sealed class MonitorUsageRequest : BaseRequest
{
    public override string GetUrl() => "https://pro-api.solscan.io/v2.0/monitor/usage";
}