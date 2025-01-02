using SolScanner.Requests;

namespace SolScanner;

public sealed class TopTokenRequest : BaseRequest
{
    public override string GetUrl()
    {
        return "https://pro-api.solscan.io/v2.0/token/top";
    }
}