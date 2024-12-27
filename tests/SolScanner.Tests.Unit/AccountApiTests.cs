using System.Globalization;
using System.Net;
using SolScanner;
using SolScanner.Requests;

namespace Solscanner.Tests.Unit;

internal sealed class TestHttpMessageHandler(
    Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> sendAsync)
    : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return sendAsync(request, cancellationToken);
    }
}


internal sealed class AccountApiTests
{
    [Test]
    public async Task GetAccountTransfer_WithValidRequest_ReturnsAccountTransfer()
    {
        // Arrange
        var fakeResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("""
                                        {
                                          "success": true,
                                          "data": [
                                            {
                                              "block_id": 275794898,
                                              "trans_id": "4AU5ShM99Db1yXr72jukaUNSJTnJtp76zt6CdL9ghatA3N4HYU9jaHre2HsHqWcKipKCD3MenvdShPsRrAU6CC4f",
                                              "block_time": 1720171655,
                                              "time": "2024-07-05T09:27:35.000Z",
                                              "activity_type": "ACTIVITY_SPL_TRANSFER",
                                              "from_address": "5Q544fKrFoe6tsEbD7S8EmxGTJYAKtTVhAW5Q5pge4j1",
                                              "to_address": "6U91aKa8pmMxkJwBCfPTmUEfZi6dHe7DcFq2ALvB2tbB",
                                              "token_address": "So11111111111111111111111111111111111111112",
                                              "token_decimals": 9,
                                              "amount": 1587870559,
                                              "flow": "in"
                                            }
                                          ]
                                        }
                                        """)
        };

        var handler = new TestHttpMessageHandler((request, cancellationToken) =>
        {
            Assert.That(request.Method, Is.EqualTo(HttpMethod.Get));
            Assert.That(request.RequestUri,
                Is.EqualTo(new Uri(
                    "https://pro-api.solscan.io/v2.0/account/transfer?address=SCre8QfQdNWNLqiFd99TBUhWAov15CuLUQ3Grf8gT8X&activity_type[]=ACTIVITY_SPL_TRANSFER&activity_type[]=ACTIVITY_SPL_BURN&token_account=7Z1vg8gwshKnrAwroK8MryWWxVTMaXvfP9BFJ6bQNTJJ&from=Aa4qpi5N2zqT2bKeqRGXdsmy237a4vWwarTsWZPbChAm&to=EZCGWhoRP844pjGaKAEJn9XukY6dN72Y3f2HX7FETpeL&token=A2N7enLeGW4n5oGVy2RwBnrfYevPKbSnrkb2W8vhwT51&amount[]=1&amount[]=2&block_time[]=1720153259&block_time[]=1720153276&exclude_amount_zero=true&flow=in&page=1337&page_size=20&sort_by=block_time&sort_order=desc")));
            return Task.FromResult(fakeResponse);
        });

        var httpClient = new HttpClient(handler);
        var apiClient = new SolscanClient("", httpClient);

        // Act
        var request = new AccountTransferRequest
        {
            Address = "SCre8QfQdNWNLqiFd99TBUhWAov15CuLUQ3Grf8gT8X",
            ActivityTypes = [EActivityType.ACTIVITY_SPL_TRANSFER, EActivityType.ACTIVITY_SPL_BURN],
            TokenAccount = "7Z1vg8gwshKnrAwroK8MryWWxVTMaXvfP9BFJ6bQNTJJ",
            From = "Aa4qpi5N2zqT2bKeqRGXdsmy237a4vWwarTsWZPbChAm",
            To = "EZCGWhoRP844pjGaKAEJn9XukY6dN72Y3f2HX7FETpeL",
            Token = "A2N7enLeGW4n5oGVy2RwBnrfYevPKbSnrkb2W8vhwT51",
            Amount = [1, 2],
            BlockTime = [1720153259, 1720153276],
            ExcludeAmountZero = true,
            Flow = EFlow.In,
            Page = 1337,
            PageSize = 20,
            SortBy = "block_time",
            SortOrder = "desc"
        };
        var result = await apiClient.GetAccountTransfer(request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Empty);
            Assert.That(result.Data[0].BlockId, Is.EqualTo(275794898));
            Assert.That(result.Data[0].TransId,
                Is.EqualTo("4AU5ShM99Db1yXr72jukaUNSJTnJtp76zt6CdL9ghatA3N4HYU9jaHre2HsHqWcKipKCD3MenvdShPsRrAU6CC4f"));
            Assert.That(result.Data[0].BlockTime, Is.EqualTo(1720171655));
            Assert.That(
                result.Data[0].Time.ToUniversalTime(),
                Is.EqualTo(DateTime.Parse("2024-07-05T09:27:35.000Z", CultureInfo.InvariantCulture).ToUniversalTime())
            );
            Assert.That(result.Data[0].ActivityType, Is.EqualTo(EActivityType.ACTIVITY_SPL_TRANSFER));
            Assert.That(result.Data[0].FromAddress, Is.EqualTo("5Q544fKrFoe6tsEbD7S8EmxGTJYAKtTVhAW5Q5pge4j1"));
            Assert.That(result.Data[0].ToAddress, Is.EqualTo("6U91aKa8pmMxkJwBCfPTmUEfZi6dHe7DcFq2ALvB2tbB"));

            Assert.That(result.Data[0].TokenAddress, Is.EqualTo("So11111111111111111111111111111111111111112"));
            Assert.That(result.Data[0].TokenDecimals, Is.EqualTo(9));
            Assert.That(result.Data[0].Amount, Is.EqualTo(1587870559));
            Assert.That(result.Data[0].Flow, Is.EqualTo(EFlow.In));
        });
    }

    [Test]
    public async Task GetAccountTokenAccounts_WithValidRequest_ReturnsAccountTransfer()
    {
        // Arrange
        var fakeResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("""
                                        {
                                          "success": true,
                                          "data": [
                                            {
                                              "token_account": "BW4bvMP129TtQkMKFebCqMA7ZC4jBop4yW8PHgTr6u8Z",
                                              "token_address": "9LbdhSersRjbkcWWdd4Xpgr8ADi16dwzMU1tM1Ddsq79",
                                              "amount": 12000000000000,
                                              "token_decimals": 4,
                                              "owner": "GThUX1Atko4tqhN2NaiTazWSeFWMuiUvfFnyJyUghFMJ"
                                            }
                                          ]
                                        }
                                        """)
        };

        var handler = new TestHttpMessageHandler((request, cancellationToken) =>
        {
            Assert.That(request.Method, Is.EqualTo(HttpMethod.Get));
            Assert.That(request.RequestUri,
                Is.EqualTo(new Uri(
                    "https://pro-api.solscan.io/v2.0/account/token-accounts?address=Fj5YcVxtTFsJtoEyAMYCFWunmQnVdJUF4d8kQWB8kyKj&page=1337&page_size=10&type=nft&hide_zero=false")));
            return Task.FromResult(fakeResponse);
        });

        var httpClient = new HttpClient(handler);
        var apiClient = new SolscanClient("", httpClient);

        // Act
        var request = new AccountTokenAccountsRequest
        {
            Address = "Fj5YcVxtTFsJtoEyAMYCFWunmQnVdJUF4d8kQWB8kyKj",
            TokenType = ETokenType.nft,
            Page = 1337,
            PageSize = 10,
            HideZero = false
        };
        var result = await apiClient.GetAccountTokenAccounts(request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Empty);
            Assert.That(result.Data[0].TokenAddress, Is.EqualTo("9LbdhSersRjbkcWWdd4Xpgr8ADi16dwzMU1tM1Ddsq79"));
            Assert.That(result.Data[0].TokenDecimals, Is.EqualTo(4));
            Assert.That(result.Data[0].Amount, Is.EqualTo(12000000000000));
            Assert.That(result.Data[0].Owner, Is.EqualTo("GThUX1Atko4tqhN2NaiTazWSeFWMuiUvfFnyJyUghFMJ"));
        });
    }

    [Test]
    public async Task GetAccountDefiActivity_WithValidRequest_ReturnsAccountTransfer()
    {
        // Arrange
        var fakeResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("""
                                        {
                                          "success": true,
                                          "data": [
                                            {
                                              "block_id": 275994804,
                                              "trans_id": "sgccc7AnmQ7mUxk7JPVZWSqD18Dm4eaMv61jte9sWjBakck5QK3UFSLnxMAqwiTUHjF8BXvaHaLAWnzGPRi77Cr",
                                              "block_time": 1720263055,
                                              "time": "2024-07-06T10:50:55.000Z",
                                              "activity_type": "ACTIVITY_AGG_TOKEN_SWAP",
                                              "from_address": "ob2htHLoCu2P6tX7RrNVtiG1mYTas8NGJEVLaFEUngk",
                                              "to_address": "JUP6LkbZbjS1jKKwapdHNy74zcZ3tLUZoi5QNyVTaV4",
                                              "sources": [
                                                "CAMMCzo5YL8w4VFF8KVHrK22GGUsp5VTaW7grrKgrWqK"
                                              ],
                                              "platform": "JUP6LkbZbjS1jKKwapdHNy74zcZ3tLUZoi5QNyVTaV4",
                                              "amount_info": {
                                                "token1": "EPjFWdd5AufqSSqeM2qN1xzybapC8G4wEGGkZwyTDt1v",
                                                "token1_decimals": 6,
                                                "amount1": 1000000,
                                                "token2": "EKpQGSJtjMFqKZ9KQanSqYXRcF8fBopzLHYxdM65zcjm",
                                                "token2_decimals": 6,
                                                "amount2": 503392,
                                                "routers": [
                                                  {
                                                    "token1": "EPjFWdd5AufqSSqeM2qN1xzybapC8G4wEGGkZwyTDt1v",
                                                    "token1_decimals": 6,
                                                    "amount1": "1000000",
                                                    "token2": "EKpQGSJtjMFqKZ9KQanSqYXRcF8fBopzLHYxdM65zcjm",
                                                    "token2_decimals": 6,
                                                    "amount2": "503392"
                                                  }
                                                ]
                                              }
                                            }
                                          ]
                                        }
                                        """)
        };

        var handler = new TestHttpMessageHandler((request, cancellationToken) =>
        {
            Assert.That(request.Method, Is.EqualTo(HttpMethod.Get));
            Assert.That(request.RequestUri,
                Is.EqualTo(new Uri(
                    "https://pro-api.solscan.io/v2.0/account/defi/activities?address=28rZz9qDU3svxWv75cmWJ2YoYy9wiBk7gxVrPjavYgsa&platform[]=9mXWMVboLKkkuSEYnntTeqq7sY6efmMHNAyp5v8ZXujy&platform[]=7MTKDg16kGmsHzjYrr4LScy4DnnpE2GohhLpAyKZYeFn&source[]=7MTKDg16kGmsHzjYrr4LScy4DnnpE2GohhLpAyKZYeFn&activity_type[]=ACTIVITY_TOKEN_SWAP&activity_type[]=ACTIVITY_SPL_TOKEN_WITHDRAW_STAKE&from=4UQC7Wy6WXdWfGyZS1Np1MAHfsgRy7t39EX6G3yJW5BZ&token=4gh6K59P7N5m63ynx5YEgV7Vd77PzmBPGRYAPGJn2SYv&block_time[]=1720153259&block_time[]=1720153276&page=1337&page_size=20&sort_by=block_time&sort_order=desc")));
            return Task.FromResult(fakeResponse);
        });

        var httpClient = new HttpClient(handler);
        var apiClient = new SolscanClient("", httpClient);

        // Act
        var request = new AccountDefiActivityRequest
        {
            Address = "28rZz9qDU3svxWv75cmWJ2YoYy9wiBk7gxVrPjavYgsa",
            ActivityTypes =
                [EDefiActivityType.ACTIVITY_TOKEN_SWAP, EDefiActivityType.ACTIVITY_SPL_TOKEN_WITHDRAW_STAKE],
            From = "4UQC7Wy6WXdWfGyZS1Np1MAHfsgRy7t39EX6G3yJW5BZ",
            Platform =
            [
                "9mXWMVboLKkkuSEYnntTeqq7sY6efmMHNAyp5v8ZXujy",
                "7MTKDg16kGmsHzjYrr4LScy4DnnpE2GohhLpAyKZYeFn"
            ],
            Sources = ["7MTKDg16kGmsHzjYrr4LScy4DnnpE2GohhLpAyKZYeFn"],
            Token = "4gh6K59P7N5m63ynx5YEgV7Vd77PzmBPGRYAPGJn2SYv",
            BlockTimes = [1720153259, 1720153276],
            Page = 1337,
            PageSize = 20,
            SortBy = "block_time",
            SortOrder = "desc",
        };
        var result = await apiClient.GetAccountDefiActivity(request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Empty);
            Assert.That(result.Data[0].BlockId, Is.EqualTo(275994804));
            Assert.That(result.Data[0].TransId,
                Is.EqualTo("sgccc7AnmQ7mUxk7JPVZWSqD18Dm4eaMv61jte9sWjBakck5QK3UFSLnxMAqwiTUHjF8BXvaHaLAWnzGPRi77Cr"));
            Assert.That(result.Data[0].BlockTime, Is.EqualTo(1720263055));
            Assert.That(result.Data[0].Time.ToUniversalTime(),
                Is.EqualTo(DateTime.Parse("2024-07-06T10:50:55.000Z").ToUniversalTime()));
            Assert.That(result.Data[0].ActivityType, Is.EqualTo(EDefiActivityType.ACTIVITY_AGG_TOKEN_SWAP));
            Assert.That(result.Data[0].FromAddress, Is.EqualTo("ob2htHLoCu2P6tX7RrNVtiG1mYTas8NGJEVLaFEUngk"));
            Assert.That(result.Data[0].ToAddress, Is.EqualTo("JUP6LkbZbjS1jKKwapdHNy74zcZ3tLUZoi5QNyVTaV4"));
            Assert.That(result.Data[0].Sources, Is.EqualTo(["CAMMCzo5YL8w4VFF8KVHrK22GGUsp5VTaW7grrKgrWqK"]));
            Assert.That(result.Data[0].Platform, Is.EqualTo("JUP6LkbZbjS1jKKwapdHNy74zcZ3tLUZoi5QNyVTaV4"));
            Assert.That(result.Data[0].AmountInfo, Is.Not.Null);
            Assert.That(result.Data[0].AmountInfo.Token1, Is.EqualTo("EPjFWdd5AufqSSqeM2qN1xzybapC8G4wEGGkZwyTDt1v"));
            Assert.That(result.Data[0].AmountInfo.Token1Decimals, Is.EqualTo(6));
            Assert.That(result.Data[0].AmountInfo.Amount1, Is.EqualTo(1000000));
            Assert.That(result.Data[0].AmountInfo.Token2, Is.EqualTo("EKpQGSJtjMFqKZ9KQanSqYXRcF8fBopzLHYxdM65zcjm"));
            Assert.That(result.Data[0].AmountInfo.Token2Decimals, Is.EqualTo(6));
            Assert.That(result.Data[0].AmountInfo.Amount2, Is.EqualTo(503392));
        });
    }
}