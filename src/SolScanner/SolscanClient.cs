using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace SolScanner;

public sealed class SolscanClient(string apiKey) : ISolscanClient
{
    private readonly HttpClient _client = new();

    #region Free Tier

    public async Task<SolscanResponse<ChainInformation>> GetChainInformation()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://public-api.solscan.io/chaininfo");

        var content = new StringContent(string.Empty);
        request.Headers.Add("token", apiKey);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        request.Content = content;

        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<SolscanResponse<ChainInformation>>(json);
    }

    #endregion
    
    #region Account APIS

    /// <summary>
    /// Get transfer data of an account
    /// </summary>
    /// <param name="address">Solana wallet address</param>
    /// <param name="activityTypes">Type of transfer <see cref="EActivityType"/></param>
    /// <param name="tokenAccount">Filter transfers for a specific token account in the wallet</param>
    /// <param name="from">Filter transfer data with direction is from an address</param>
    /// <param name="to">Filter transfers from a specific address</param>
    /// <param name="token">Filter by token address. For native SOL transfers, use So11111111111111111111111111111111111111111</param>
    /// <param name="amount">Filter by amount range for a specific token. Example: ?amount[]=1&amount[]=2&token=So11111111111111111111111111111111111111112</param>
    /// <param name="blockTime">Filter by block time range (Unix timestamp in seconds). Example: ?block_time[]=1720153259&block_time[]=1720153276</param>
    /// <param name="excludeAmountZero">Exclude transfers with zero amount</param>
    /// <param name="flow">Filter by transfer direction: in or out. <see cref="EFlow"/></param>
    /// <param name="page">Page number for pagination</param>
    /// <param name="pageSize">Number of items per page</param>
    /// <param name="sortOrder">The parameter allows you to specify the field by which the returned list will be sorted</param>
    /// <returns></returns>
    public async Task<SolscanResponse<Transfer>> GetAccountTransfer(string address, EActivityType[] activityTypes,
        string tokenAccount, string from, string to, string token, uint[] amount, uint[] blockTime,
        bool excludeAmountZero, string flow, uint page, uint pageSize, string sortOrder)
    {
        // Build URL
        var url = new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/account/transfer")
            .WithAddress(address)
            .WithActivityTypes(activityTypes)
            .WithTokenAccount(tokenAccount)
            .WithFrom(from)
            .WithTo(to)
            .WithToken(token)
            .WithAmounts(amount)
            .WithBlockTimes(blockTime)
            .ExcludeAmountZero(excludeAmountZero)
            .WithFlow(flow)
            .WithPage(page)
            .WithPageSize(pageSize)
            .WithSortOrder(sortOrder)
            .Build();
        
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        request.Headers.Add("content-Type", "application/json");

        var content = new StringContent(string.Empty);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        request.Content = content;

        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<SolscanResponse<Transfer>>(json);
    }

    /// <summary>
    /// Get token accounts of an account
    /// </summary>
    /// <param name="address">Solana wallet address</param>
    /// <param name="tokenType"></param>
    /// <param name="page">Page number for pagination</param>
    /// <param name="pageSize">Number of items per page</param>
    /// <param name="hideZero"></param>
    /// <returns></returns>
    public async Task<SolscanResponse<TokenAccountData>> GetAccountTokenAccounts(string address, ETokenType tokenType,
        uint page, uint pageSize, bool hideZero)
    {
        // Build URL
        var url = new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/account/transfer")
            .WithAddress(address)
            .WithTokenType(tokenType)
            .WithPage(page)
            .WithPageSize(pageSize)
            .WithHideZero(hideZero)
            .Build();
        
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        request.Headers.Add("content-Type", "application/json");

        var content = new StringContent(string.Empty);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        request.Content = content;

        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<SolscanResponse<TokenAccountData>>(json);
    }

    #endregion
}

public interface ISolscanClient;