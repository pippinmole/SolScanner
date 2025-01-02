using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using SolScanner.Requests;
using SolScanner.Responses;

namespace SolScanner;

public sealed class SolscanClient(string apiKey, HttpClient client) : ISolscanClient
{
    #region Free Tier

    public Task<SolscanResponse<ChainInformation>> GetChainInformation(CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<ChainInformation>>(new ChainInformationRequest(), token);

    #endregion

    #region Account APIS

    /// <summary>
    /// Get transfer data of an account
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<Transfer>>> GetAccountTransfer(AccountTransferRequest r,
        CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<List<Transfer>>>(r, token);

    /// <summary>
    /// Get token accounts of an account
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<TokenAccountData>>> GetAccountTokenAccounts(AccountTokenAccountsRequest r,
        CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<List<TokenAccountData>>>(r, token);

    /// <summary>
    /// Get defi activities involving an account
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<DefiActivityData>>> GetAccountDefiActivity(AccountDefiActivityRequest r,
        CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<List<DefiActivityData>>>(r, token);

    /// <summary>
    /// Get balance change activities involving an account
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<BalanceChangeActivity>>> GetAccountBalanceChangeActivities(
        AccountBalanceChangeActivitiesRequest r, CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<List<BalanceChangeActivity>>>(r, token);

    /// <summary>
    /// Get balance change activities involving an account
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<AccountTransaction>>> GetAccountTransactions(AccountTransactionsRequest r,
        CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<List<AccountTransaction>>>(r, token);

    /// <summary>
    /// Get the list of stake accounts of an account
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<AccountStake>>> GetAccountStakes(AccountStakesRequest r,
        CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<List<AccountStake>>>(r, token);

    /// <summary>
    /// Get the list of stake accounts of an account
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<AccountDetailsResponse>> GetAccountDetails(AccountDetailsRequest r,
        CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<AccountDetailsResponse>>(r, token);

    // /// <summary>
    // /// Export the rewards for an account. Maximum items: 5000
    // /// </summary>
    // /// <param name="r"></param>
    // /// <param name="token"></param>
    // /// <returns></returns>
    // public Task<SolscanResponse<List<AccountStake>>> GetAccountRewardsExport(AccountRewardsExportRequest r, CancellationToken token) =>
    //     WithRequestAsync<SolscanResponse<List<AccountStake>>>(r, token);

    // /// <summary>
    // /// Export transfer data of an account
    // /// </summary>
    // /// <param name="r"></param>
    // /// <returns></returns>
    // public Task<SolscanResponse<List<AccountStake>>> GetAccountTransportExport(AccountTransferExportRequest r, token) =>
    //     WithRequest<SolscanResponse<List<AccountStake>>>(r, token);    

    #endregion

    #region Token APIs

    /// <summary>
    /// Get transfer data of a token
    /// </summary>
    /// <param name="r"></param>
    /// <param name="ctx"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<TokenTransfer>>> GetTokenTransfers(GetTokenTransferRequest r, CancellationToken ctx) =>
        WithRequestAsync<SolscanResponse<List<TokenTransfer>>>(r, ctx);

    /// <summary>
    /// Get defi activities involving a token
    /// </summary>
    /// <param name="r"></param>
    /// <param name="ctx"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<TokenDefiActivityData>>> GetTokenDefiActivities(TokenDefiActivitiesRequest r, CancellationToken ctx) =>
    WithRequestAsync<SolscanResponse<List<TokenDefiActivityData>>>(r, ctx);

    /// <summary>
    /// Get the list of tokens
    /// </summary>
    /// <param name="r"></param>
    /// <param name="ctx"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<Token>>> GetTokenList(GetTokenListRequest r, CancellationToken ctx) =>
        WithRequestAsync<SolscanResponse<List<Token>>>(r, ctx);

    /// <summary>
    /// Get the list of trending tokens
    /// </summary>
    /// <param name="r"></param>
    /// <param name="ctx"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<TrendingToken>>> GetTrendingTokens(TrendingTokenRequest r, CancellationToken ctx) =>
        WithRequestAsync<SolscanResponse<List<TrendingToken>>>(r, ctx);
    
    /// <summary>
    /// Get the list of trending tokens
    /// </summary>
    /// <param name="r"></param>
    /// <param name="ctx"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<TokenPrice>>> GetTokenPrice(TokenPriceRequest r, CancellationToken ctx) =>
        WithRequestAsync<SolscanResponse<List<TokenPrice>>>(r, ctx);
    
    /// <summary>
    /// Get the list of trending tokens
    /// </summary>
    /// <param name="r"></param>
    /// <param name="ctx"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<TopToken>>> GetTopToken(CancellationToken ctx) =>
        WithRequestAsync<SolscanResponse<List<TopToken>>>(new TopTokenRequest(), ctx);

    #endregion

    #region NFT APIs

    #endregion

    #region Transaction APIs

    /// <summary>
    /// Get the list of the latest transactions
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<LastTransaction>>> GetLastTransactions(LastTransactionsRequest r,
        CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<List<LastTransaction>>>(r, token);

    /// <summary>
    /// Get the detail of a transaction. Return transaction data after parsed by Solscan Parser. Data will include very helpful data such as: token and sol balance changes, IDL data, defi or transfer activities of each instructions
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<TransactionDetailsResponse>> GetTransactionDetails(TransactionDetailsRequest r,
        CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<TransactionDetailsResponse>>(r, token);

    #endregion

    #region Block APIs

    /// <summary>
    /// Get the list of the latest blocks
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<Block>>> GetLastBlock(LastBlockRequest r, CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<List<Block>>>(r, token);

    /// <summary>
    /// Get the list of transactions of a block
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<BlockTransactionsResponse>> GetBlockTransactions(BlockTransactionsRequest r,
        CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<BlockTransactionsResponse>>(r, token);

    /// <summary>
    /// Get the details of a block
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<BlockDetailsResponse>> GetBlockDetails(BlockDetailsRequest r,
        CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<BlockDetailsResponse>>(r, token);

    #endregion

    #region Monitoring APIs

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<MonitorUsageResponse>> GetMonitorUsage(CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<MonitorUsageResponse>>(new MonitorUsageRequest(), token);

    #endregion

    #region Market APIs

    /// <summary>
    /// Get the list of pool markets
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<List<PoolMarket>>> GetPoolMarketList(PoolMarketListRequest r,
        CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<List<PoolMarket>>>(r, token);

    /// <summary>
    /// Get token market info
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<MarketInfoResponse>> GetMarketInfo(MarketInfoRequest r,
        CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<MarketInfoResponse>>(r, token);

    /// <summary>
    /// Get the list of pool markets
    /// </summary>
    /// <param name="r"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SolscanResponse<MarketVolumeResponse>> GetMarketVolume(MarketVolumeRequest r,
        CancellationToken token = default) =>
        WithRequestAsync<SolscanResponse<MarketVolumeResponse>>(r, token);

    #endregion

    /// <summary>
    /// Sends an HTTP GET request using the provided <see cref="BaseRequest"/> 
    /// and returns a deserialized response of type <typeparamref name="T"/>.
    /// </summary>
    /// <remarks>
    /// This method attempts to deserialize the response content as JSON even for 
    /// HTTP status codes 400 (Bad Request). For any other non-success status code, an 
    /// exception is thrown.
    /// </remarks>
    /// <typeparam name="T">The type into which the JSON response is deserialized.</typeparam>
    /// <param name="req">The <see cref="BaseRequest"/> object containing request parameters and URL.</param>
    /// <param name="ctx"></param>
    /// <returns>
    /// A task representing the asynchronous operation, containing the deserialized 
    /// object of type <typeparamref name="T"/>.
    /// </returns>
    /// <exception cref="HttpRequestException">
    /// Thrown if the response has a non-success status code that is not one of 
    /// 400, 401, 429, or 500 (i.e., <see cref="HttpResponseMessage.EnsureSuccessStatusCode"/> 
    /// is called for unrecognized errors).
    /// </exception>
    /// <exception cref="JsonException">
    /// Thrown if the content of the response cannot be deserialized into 
    /// <typeparamref name="T"/>.
    /// </exception>
    /// <exception cref="TaskCanceledException">
    /// Thrown if the request times out before it can complete.
    /// </exception>
    /// <exception cref="OperationCanceledException">
    /// Thrown if the request is canceled.
    /// </exception>
    private async Task<T> WithRequestAsync<T>(BaseRequest req, CancellationToken ctx)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, req.GetUrl());

        var content = new StringContent(string.Empty);
        request.Headers.Add("token", apiKey);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        request.Content = content;

        var response = await client.SendAsync(request, ctx);

        // Check status code. If it’s not success and not one of the "parse-anyway" codes, throw.
        if (!response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.BadRequest)
        {
            response.EnsureSuccessStatusCode();
        }

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json);
    }
}

public sealed class TopTokenRequest : BaseRequest
{
    public override string GetUrl()
    {
        return "https://pro-api.solscan.io/v2.0/token/top";
    }
}

public interface ISolscanClient;