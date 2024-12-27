using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using SolScanner.Requests;
using SolScanner.Responses;

namespace SolScanner;

public sealed class SolscanClient(string apiKey, HttpClient client) : ISolscanClient
{
    #region Free Tier

    public Task<SolscanResponse<ChainInformation>> GetChainInformation() =>
        WithRequest<SolscanResponse<ChainInformation>>(new ChainInformationRequest());

    #endregion

    #region Account APIS

    /// <summary>
    /// Get transfer data of an account
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<Transfer>>> GetAccountTransfer(AccountTransferRequest r) =>
        WithRequest<SolscanResponse<List<Transfer>>>(r);

    /// <summary>
    /// Get token accounts of an account
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<TokenAccountData>>> GetAccountTokenAccounts(AccountTokenAccountsRequest r) => 
        WithRequest<SolscanResponse<List<TokenAccountData>>>(r);

    /// <summary>
    /// Get defi activities involving an account
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<DefiActivityData>>> GetAccountDefiActivity(AccountDefiActivityRequest r) => 
        WithRequest<SolscanResponse<List<DefiActivityData>>>(r);

    /// <summary>
    /// Get balance change activities involving an account
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<BalanceChangeActivity>>> GetAccountBalanceChangeActivities(AccountBalanceChangeActivitiesRequest r) =>
        WithRequest<SolscanResponse<List<BalanceChangeActivity>>>(r);
    
    /// <summary>
    /// Get balance change activities involving an account
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<AccountTransaction>>> GetAccountTransactions(AccountTransactionsRequest r) =>
        WithRequest<SolscanResponse<List<AccountTransaction>>>(r);    
    
    /// <summary>
    /// Get the list of stake accounts of an account
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<AccountStake>>> GetAccountStakes(AccountStakesRequest r) =>
        WithRequest<SolscanResponse<List<AccountStake>>>(r);
    
    /// <summary>
    /// Get the list of stake accounts of an account
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<AccountDetailsResponse>> GetAccountDetails(AccountDetailsRequest r) =>
        WithRequest<SolscanResponse<AccountDetailsResponse>>(r);
    
    /// <summary>
    /// Export the rewards for an account. Maximum items: 5000
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<AccountStake>>> GetAccountRewardsExport(AccountRewardsExportRequest r) =>
        WithRequest<SolscanResponse<List<AccountStake>>>(r);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public Task<SolscanResponse<List<AccountStake>>> GetAccountTransportExport(AccountTransferExportRequest r) =>
        WithRequest<SolscanResponse<List<AccountStake>>>(r);    
    #endregion

    #region Token APIs
    
    #endregion
    
    #region NFT APIs
    
    #endregion
    
    #region Transaction APIs

    /// <summary>
    /// Get the list of the latest transactions
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<LastTransaction>>> GetLastTransactions(LastTransactionsRequest r) =>
        WithRequest<SolscanResponse<List<LastTransaction>>>(r);
    
    /// <summary>
    /// Get the detail of a transaction. Return transaction data after parsed by Solscan Parser. Data will include very helpful data such as: token and sol balance changes, IDL data, defi or transfer activities of each instructions
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<LastTransaction>>> GetTransactionDetails(TransactionDetailsRequest r) =>
        WithRequest<SolscanResponse<List<LastTransaction>>>(r);
    
    #endregion
    
    #region Block APIs

    /// <summary>
    /// Get the list of the latest blocks
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<Block>>> GetLastBlock(LastBlockRequest r) =>
        WithRequest<SolscanResponse<List<Block>>>(r);
    
    /// <summary>
    /// Get the list of transactions of a block
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<BlockTransactionsResponse>> GetBlockTransactions(BlockTransactionsRequest r) =>
        WithRequest<SolscanResponse<BlockTransactionsResponse>>(r);
    
    /// <summary>
    /// Get the details of a block
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<BlockDetailsResponse>> GetBlockDetails(BlockDetailsRequest r) =>
        WithRequest<SolscanResponse<BlockDetailsResponse>>(r);
    
    #endregion
    
    #region Monitoring APIs
    
    public Task<SolscanResponse<MonitorUsageResponse>> GetMonitorUsage() =>
        WithRequest<SolscanResponse<MonitorUsageResponse>>(new MonitorUsageRequest());
    
    #endregion
    
    #region Market APIs
    
    /// <summary>
    /// Get the list of pool markets
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<PoolMarket>>> GetPoolMarketList(PoolMarketListRequest r) =>
        WithRequest<SolscanResponse<List<PoolMarket>>>(r);
    
    /// <summary>
    /// Get token market info
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<MarketInfoResponse>> GetMarketInfo(MarketInfoRequest r) =>
        WithRequest<SolscanResponse<MarketInfoResponse>>(r);
    
    /// <summary>
    /// Get the list of pool markets
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public Task<SolscanResponse<MarketVolumeResponse>> GetMarketVolume(MarketVolumeRequest r) =>
        WithRequest<SolscanResponse<MarketVolumeResponse>>(r);
    
    #endregion
    
    private async Task<T> WithRequest<T>(BaseRequest req)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, req.GetUrl());

        var content = new StringContent(string.Empty);
        request.Headers.Add("token", apiKey);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        request.Content = content;

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json);
    }
}

public interface ISolscanClient;