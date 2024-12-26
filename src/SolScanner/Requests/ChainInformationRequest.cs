namespace SolScanner.Requests;

public sealed class ChainInformationRequest : BaseRequest
{
    public override string GetUrl() => "https://public-api.solscan.io/chaininfo";
}