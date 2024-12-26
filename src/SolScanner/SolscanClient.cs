using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using SolScanner.Requests;
using SolScanner.Responses;

namespace SolScanner;

public sealed class SolscanClient(string apiKey) : ISolscanClient
{
    private readonly HttpClient _client = new();

    #region Free Tier

    public Task<SolscanResponse<ChainInformation>> GetChainInformation() =>
        WithRequest<SolscanResponse<ChainInformation>>(new ChainInformationRequest().GetUrl());

    #endregion

    #region Account APIS

    /// <summary>
    /// Get transfer data of an account
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<Transfer>> GetAccountTransfer(AccountTransferRequest r) =>
        WithRequest<SolscanResponse<Transfer>>(r.GetUrl());

    /// <summary>
    /// Get token accounts of an account
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<TokenAccountData>> GetAccountTokenAccounts(AccountTokenAccountsRequest r) => 
        WithRequest<SolscanResponse<TokenAccountData>>(r.GetUrl());

    /// <summary>
    /// Get defi activities involving an account
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<DefiActivityData>>> GetAccountDefiActivity(AccountDefiActivityRequest r) => 
        WithRequest<SolscanResponse<List<DefiActivityData>>>(r.GetUrl());

    /// <summary>
    /// Get balance change activities involving an account
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<BalanceChangeActivity>>> GetAccountBalanceChangeActivities(AccountBalanceChangeActivitiesRequest r) =>
        WithRequest<SolscanResponse<List<BalanceChangeActivity>>>(r.GetUrl());
    
    /// <summary>
    /// Get balance change activities involving an account
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<AccountTransaction>>> GetAccountTransactions(AccountTransactionsRequest r) =>
        WithRequest<SolscanResponse<List<AccountTransaction>>>(r.GetUrl());    
    
    /// <summary>
    /// Get the list of stake accounts of an account
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<AccountStake>>> GetAccountStakes(AccountStakesRequest r) =>
        WithRequest<SolscanResponse<List<AccountStake>>>(r.GetUrl());
    
    /// <summary>
    /// Get the list of stake accounts of an account
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<AccountStake>>> GetAccountDetails(AccountDetailsRequest r) =>
        WithRequest<SolscanResponse<List<AccountStake>>>(r.GetUrl());
    
    /// <summary>
    /// Export the rewards for an account. Maximum items: 5000
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<AccountStake>>> GetAccountRewardsExport(AccountRewardsExportRequest r) =>
        WithRequest<SolscanResponse<List<AccountStake>>>(r.GetUrl());
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public Task<SolscanResponse<List<AccountStake>>> GetAccountTransportExport(AccountTransferExportRequest r) =>
        WithRequest<SolscanResponse<List<AccountStake>>>(r.GetUrl());    
    #endregion

    private async Task<T> WithRequest<T>(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        var content = new StringContent(string.Empty);
        request.Headers.Add("token", apiKey);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        request.Content = content;

        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json);
    }
}

public interface ISolscanClient;