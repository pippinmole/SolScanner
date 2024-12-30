using System.Globalization;
using System.Net;
using System.Numerics;
using SolScanner;
using SolScanner.Requests;

namespace Solscanner.Tests.Unit;

internal sealed class SolscanClientTests
{
    #region Account APIs

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
            SortOrder = ESortOrder.Descending
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

    [Test]
    public async Task GetAccountBalanceChangeActivities_WithValidRequest_ReturnsAccountTransfer()
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
                                              "block_id": 245299423,
                                              "block_time": 1706718634,
                                              "time": "2024-01-31T16:30:34.000Z",
                                              "trans_id": "2njDKnCCqM9XEsN3TxqbQdPMg6sTSijevfoinsSMg1hZMhn2ubFCtHRR6ux9huLKd7hAPMxCGKJqZ2wcNveoQyDS",
                                              "address": "9KR7WY8ebL5jD99tmzi3RFmk4v4ahwwHQKdqpG47Vsrg",
                                              "token_address": "JUPyiwrYJFskUPiHa7hkeR8VUtAeFoSYbKedZNsDvCN",
                                              "token_account": "FSmkHGcjmGuQaB2aKBqnsg35aajitvqjDWiJi9PdFpxB",
                                              "token_decimals": 6,
                                              "amount": 200000000,
                                              "pre_balance": 0,
                                              "post_balance": 200000000,
                                              "change_type": "inc",
                                              "fee": 1005000
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
                    "https://pro-api.solscan.io/v2.0/account/balance_change?address=GCUEeFgWWcAouA8KvXbY235qcRvn3pQKKbPjYTrxdiiC&token=AtDQpv27wsScSqpMFtTZvhXo6C3PcLnxa5X8YZqjh6ar&amount[]=1&amount[]=2&block_time[]=1720153259&block_time[]=1720153276&remove_spam=true&flow=in&page=1337&page_size=20&sort_by=block_time&sort_order=desc")));
            return Task.FromResult(fakeResponse);
        });

        var httpClient = new HttpClient(handler);
        var apiClient = new SolscanClient("", httpClient);

        // Act
        var request = new AccountBalanceChangeActivitiesRequest
        {
            Address = "GCUEeFgWWcAouA8KvXbY235qcRvn3pQKKbPjYTrxdiiC",
            Token = "AtDQpv27wsScSqpMFtTZvhXo6C3PcLnxa5X8YZqjh6ar",
            BlockTimes = [1720153259, 1720153276],
            PageSize = 20,
            Page = 1337,
            RemoveSpam = true,
            Amounts = [1, 2],
            Flow = EFlow.In,
            SortBy = "block_time",
            SortOrder = "desc",
        };
        var result = await apiClient.GetAccountBalanceChangeActivities(request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Empty);
            Assert.That(result.Data[0].BlockId, Is.EqualTo(245299423));
            Assert.That(result.Data[0].BlockTime, Is.EqualTo(1706718634));
            Assert.That(result.Data[0].Time.ToUniversalTime(),
                Is.EqualTo(DateTime.Parse("2024-01-31T16:30:34.000Z").ToUniversalTime()));
            Assert.That(result.Data[0].TransId,
                Is.EqualTo("2njDKnCCqM9XEsN3TxqbQdPMg6sTSijevfoinsSMg1hZMhn2ubFCtHRR6ux9huLKd7hAPMxCGKJqZ2wcNveoQyDS"));
            Assert.That(result.Data[0].Address, Is.EqualTo("9KR7WY8ebL5jD99tmzi3RFmk4v4ahwwHQKdqpG47Vsrg"));
            Assert.That(result.Data[0].TokenAddress, Is.EqualTo("JUPyiwrYJFskUPiHa7hkeR8VUtAeFoSYbKedZNsDvCN"));
            Assert.That(result.Data[0].TokenAccount, Is.EqualTo("FSmkHGcjmGuQaB2aKBqnsg35aajitvqjDWiJi9PdFpxB"));
            Assert.That(result.Data[0].TokenDecimals, Is.EqualTo(6));
            Assert.That(result.Data[0].Amount, Is.EqualTo(200000000));
            Assert.That(result.Data[0].PreBalance, Is.EqualTo(0));
            Assert.That(result.Data[0].PostBalance, Is.EqualTo(200000000));
            Assert.That(result.Data[0].ChangeType, Is.EqualTo("inc"));
            Assert.That(result.Data[0].Fee, Is.EqualTo(1005000));
        });
    }

    [Test]
    public async Task GetAccountTransactions_WithValidRequest_ReturnsAccountTransfer()
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
                                              "slot": 282450328,
                                              "fee": 60601,
                                              "status": "Fail",
                                              "signer": [
                                                "ob2htHLoCu2P6tX7RrNVtiG1mYTas8NGJEVLaFEUngk"
                                              ],
                                              "block_time": 1723176170,
                                              "tx_hash": "2k5SKZo9tAgK3w24EozcCSm1doWLmqoFTe8UeSHd2pp7KJbsH4pRdM78hwfDsSTEC7edJtNYAEGryZe5L1uxU5DU",
                                              "parsed_instructions": [
                                                {
                                                  "type": "cancelAllAndPlaceOrders",
                                                  "program": "openbook_v2",
                                                  "program_id": "opnb2LAfJYbRMAHHvqjCwQxanZn7ReEHp1k81EohpZb"
                                                },
                                                {
                                                  "type": "settleFunds",
                                                  "program": "openbook_v2",
                                                  "program_id": "opnb2LAfJYbRMAHHvqjCwQxanZn7ReEHp1k81EohpZb"
                                                }
                                              ],
                                              "program_ids": [
                                                "ComputeBudget111111111111111111111111111111",
                                                "GDDMwNyyx8uB6zrqwBFHjLLG3TBYk2F8Az4yrQC5RzMp",
                                                "opnb2LAfJYbRMAHHvqjCwQxanZn7ReEHp1k81EohpZb"
                                              ],
                                              "time": "2024-08-09T04:02:50.000Z"
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
                    "https://pro-api.solscan.io/v2.0/account/transactions?address=GCUEeFgWWcAouA8KvXbY235qcRvn3pQKKbPjYTrxdiiC&before=2HY1yJ54GHRDR1jGLKQMi4xNR4cx488xeHK87z4Lh16c&limit=40")));
            return Task.FromResult(fakeResponse);
        });

        var httpClient = new HttpClient(handler);
        var apiClient = new SolscanClient("", httpClient);

        // Act
        var request = new AccountTransactionsRequest
        {
            Address = "GCUEeFgWWcAouA8KvXbY235qcRvn3pQKKbPjYTrxdiiC",
            Before = "2HY1yJ54GHRDR1jGLKQMi4xNR4cx488xeHK87z4Lh16c",
            Limit = ELimit.Fourty,
        };
        var result = await apiClient.GetAccountTransactions(request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Empty);
            Assert.That(result.Data[0].Slot, Is.EqualTo(282450328));
            Assert.That(result.Data[0].Fee, Is.EqualTo(60601));
            Assert.That(result.Data[0].Status, Is.EqualTo("Fail"));
            Assert.That(result.Data[0].Signer, Is.EqualTo(["ob2htHLoCu2P6tX7RrNVtiG1mYTas8NGJEVLaFEUngk"]));
            Assert.That(result.Data[0].BlockTime, Is.EqualTo(1723176170));
            Assert.That(result.Data[0].TxHash,
                Is.EqualTo("2k5SKZo9tAgK3w24EozcCSm1doWLmqoFTe8UeSHd2pp7KJbsH4pRdM78hwfDsSTEC7edJtNYAEGryZe5L1uxU5DU"));
            Assert.That(result.Data[0].ParsedInstructions, Is.Not.Null);
            Assert.That(result.Data[0].ParsedInstructions, Is.Not.Empty);
            Assert.That(result.Data[0].ParsedInstructions[0].Type, Is.EqualTo("cancelAllAndPlaceOrders"));
            Assert.That(result.Data[0].ParsedInstructions[0].Program, Is.EqualTo("openbook_v2"));
            Assert.That(result.Data[0].ParsedInstructions[0].ProgramId,
                Is.EqualTo("opnb2LAfJYbRMAHHvqjCwQxanZn7ReEHp1k81EohpZb"));

            Assert.That(result.Data[0].ParsedInstructions[1].Type, Is.EqualTo("settleFunds"));
            Assert.That(result.Data[0].ParsedInstructions[1].Program, Is.EqualTo("openbook_v2"));
            Assert.That(result.Data[0].ParsedInstructions[1].ProgramId,
                Is.EqualTo("opnb2LAfJYbRMAHHvqjCwQxanZn7ReEHp1k81EohpZb"));

            Assert.That(result.Data[0].Time.ToUniversalTime(),
                Is.EqualTo(DateTime.Parse("2024-08-09T04:02:50.000Z").ToUniversalTime()));
        });
    }

    [Test]
    public async Task GetAccountStakes_WithValidRequest_ReturnsAccountTransfer()
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
                                              "amount": 458814660465801,
                                              "role": [
                                                "staker",
                                                "withdrawer"
                                              ],
                                              "status": "active",
                                              "type": "active",
                                              "voter": "J1to1yufRnoWn81KYg1XkTWzmKjnYSnmE2VY8DGUJ9Qv",
                                              "active_stake_amount": 458814660465801,
                                              "delegated_stake_amount": 458814660465801,
                                              "sol_balance": 460943646092406,
                                              "total_reward": "57305913856583",
                                              "stake_account": "2P8jAu5woVjL7wWPGTdeKgybtHnVM5UDAHQTF6F4gqNn",
                                              "activation_epoch": 522,
                                              "stake_type": 522
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
                    "https://pro-api.solscan.io/v2.0/account/stake?address=GCUEeFgWWcAouA8KvXbY235qcRvn3pQKKbPjYTrxdiiC&page=1337&page_size=20")));
            return Task.FromResult(fakeResponse);
        });

        var httpClient = new HttpClient(handler);
        var apiClient = new SolscanClient("", httpClient);

        // Act
        var request = new AccountStakesRequest
        {
            Address = "GCUEeFgWWcAouA8KvXbY235qcRvn3pQKKbPjYTrxdiiC",
            Page = 1337,
            PageSize = 20,
        };
        var result = await apiClient.GetAccountStakes(request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Empty);
            Assert.That(result.Data[0].Amount, Is.EqualTo(458814660465801));
            Assert.That(result.Data[0].Role, Contains.Item("staker"));
            Assert.That(result.Data[0].Role, Contains.Item("withdrawer"));
            Assert.That(result.Data[0].Status, Is.EqualTo("active"));
            Assert.That(result.Data[0].Type, Is.EqualTo("active"));
            Assert.That(result.Data[0].Voter, Is.EqualTo("J1to1yufRnoWn81KYg1XkTWzmKjnYSnmE2VY8DGUJ9Qv"));
            Assert.That(result.Data[0].ActiveStakeAmount, Is.EqualTo(458814660465801));
            Assert.That(result.Data[0].DelegatedStakeAmount, Is.EqualTo(458814660465801));
            Assert.That(result.Data[0].SolBalance, Is.EqualTo(460943646092406));
            Assert.That(result.Data[0].TotalReward, Is.EqualTo("57305913856583"));
            Assert.That(result.Data[0].StakeAccount, Is.EqualTo("2P8jAu5woVjL7wWPGTdeKgybtHnVM5UDAHQTF6F4gqNn"));
            Assert.That(result.Data[0].ActivationEpoch, Is.EqualTo(522));
            Assert.That(result.Data[0].StakeType, Is.EqualTo(522));
        });
    }

    [Test]
    public async Task GetAccountDetails_WithValidRequest_ReturnsAccountTransfer()
    {
        // Arrange
        var fakeResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("""
                                        {
                                          "success": true,
                                          "data": {
                                            "account": "2YcwVbKx9L25Jpaj2vfWSXD5UKugZumWjzEe6suBUJi2",
                                            "lamports": 11934280,
                                            "type": "system_account",
                                            "executable": false,
                                            "owner_program": "11111111111111111111111111111111",
                                            "rent_epoch": 18446744073709552000,
                                            "is_oncurve": true
                                          }
                                        }
                                        """)
        };

        var handler = new TestHttpMessageHandler((request, cancellationToken) =>
        {
            Assert.That(request.Method, Is.EqualTo(HttpMethod.Get));
            Assert.That(request.RequestUri,
                Is.EqualTo(new Uri(
                    "https://pro-api.solscan.io/v2.0/account/detail?address=GCUEeFgWWcAouA8KvXbY235qcRvn3pQKKbPjYTrxdiiC")));
            return Task.FromResult(fakeResponse);
        });

        var httpClient = new HttpClient(handler);
        var apiClient = new SolscanClient("", httpClient);

        // Act
        var request = new AccountDetailsRequest
        {
            Address = "GCUEeFgWWcAouA8KvXbY235qcRvn3pQKKbPjYTrxdiiC"
        };
        var result = await apiClient.GetAccountDetails(request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.Account, Is.EqualTo("2YcwVbKx9L25Jpaj2vfWSXD5UKugZumWjzEe6suBUJi2"));
            Assert.That(result.Data.Lamports, Is.EqualTo(11934280));
            Assert.That(result.Data.Type, Is.EqualTo("system_account"));
            Assert.That(result.Data.Executable, Is.EqualTo(false));
            Assert.That(result.Data.OwnerProgram, Is.EqualTo("11111111111111111111111111111111"));
            Assert.That(result.Data.RentEpoch, Is.EqualTo(BigInteger.Parse("18446744073709552000")));
            Assert.That(result.Data.IsOncurve, Is.EqualTo(true));
        });
    }

    // [Test]
    // public async Task GetAccountRewardsExport_WithValidRequest_ReturnsAccountTransfer()
    // {
    //     // Arrange
    //     var fakeResponse = new HttpResponseMessage
    //     {
    //         StatusCode = HttpStatusCode.OK,
    //         Content = new StringContent("""
    //                                     {
    //                                       "success": true,
    //                                       "data": {
    //                                         "account": "2YcwVbKx9L25Jpaj2vfWSXD5UKugZumWjzEe6suBUJi2",
    //                                         "lamports": 11934280,
    //                                         "type": "system_account",
    //                                         "executable": false,
    //                                         "owner_program": "11111111111111111111111111111111",
    //                                         "rent_epoch": 18446744073709552000,
    //                                         "is_oncurve": true
    //                                       }
    //                                     }
    //                                     """)
    //     };
    //
    //     var handler = new TestHttpMessageHandler((request, cancellationToken) =>
    //     {
    //         Assert.That(request.Method, Is.EqualTo(HttpMethod.Get));
    //         Assert.That(request.RequestUri,
    //             Is.EqualTo(new Uri(
    //                 "https://pro-api.solscan.io/v2.0/account/reward/export?address=GCUEeFgWWcAouA8KvXbY235qcRvn3pQKKbPjYTrxdiiC&time_from=1735261949&time_to=1703639549")));
    //         return Task.FromResult(fakeResponse);
    //     });
    //
    //     var httpClient = new HttpClient(handler);
    //     var apiClient = new SolscanClient("", httpClient);
    //
    //     // Act
    //     var request = new AccountRewardsExportRequest
    //     {
    //         Address = "GCUEeFgWWcAouA8KvXbY235qcRvn3pQKKbPjYTrxdiiC",
    //         TimeFrom = 1735261949,
    //         TimeTo = 1703639549
    //     };
    //     var result = await apiClient.GetAccountRewardsExport(request);
    //
    //     // Assert
    //     Assert.Multiple(() =>
    //     {
    //         Assert.That(result, Is.Not.Null);
    //         Assert.That(result.Success, Is.True);
    //         Assert.That(result.Data, Is.Not.Null);
    //         Assert.That(result.Data.Account, Is.EqualTo("2YcwVbKx9L25Jpaj2vfWSXD5UKugZumWjzEe6suBUJi2"));
    //         Assert.That(result.Data.Lamports, Is.EqualTo(11934280));
    //         Assert.That(result.Data.Type, Is.EqualTo("system_account"));
    //         Assert.That(result.Data.Executable, Is.EqualTo(false));
    //         Assert.That(result.Data.OwnerProgram, Is.EqualTo("11111111111111111111111111111111"));
    //         Assert.That(result.Data.RentEpoch, Is.EqualTo(BigInteger.Parse("18446744073709552000")));
    //         Assert.That(result.Data.IsOncurve, Is.EqualTo(true));
    //     });
    // }
    //
    // [Test]
    // public async Task GetAccountTransportExport_WithValidRequest_ReturnsAccountTransfer()
    // {
    //     // Arrange
    //     var fakeResponse = new HttpResponseMessage
    //     {
    //         StatusCode = HttpStatusCode.OK,
    //         Content = new StringContent("""
    //                                     {
    //                                       "success": true,
    //                                       "data": {
    //                                         "account": "2YcwVbKx9L25Jpaj2vfWSXD5UKugZumWjzEe6suBUJi2",
    //                                         "lamports": 11934280,
    //                                         "type": "system_account",
    //                                         "executable": false,
    //                                         "owner_program": "11111111111111111111111111111111",
    //                                         "rent_epoch": 18446744073709552000,
    //                                         "is_oncurve": true
    //                                       }
    //                                     }
    //                                     """)
    //     };
    //
    //     var handler = new TestHttpMessageHandler((request, cancellationToken) =>
    //     {
    //         Assert.That(request.Method, Is.EqualTo(HttpMethod.Get));
    //         Assert.That(request.RequestUri,
    //             Is.EqualTo(new Uri(
    //                 "https://pro-api.solscan.io/v2.0/account/detail?address=GCUEeFgWWcAouA8KvXbY235qcRvn3pQKKbPjYTrxdiiC")));
    //         return Task.FromResult(fakeResponse);
    //     });
    //
    //     var httpClient = new HttpClient(handler);
    //     var apiClient = new SolscanClient("", httpClient);
    //
    //     // Act
    //     var request = new AccountDetailsRequest
    //     {
    //         Address = "GCUEeFgWWcAouA8KvXbY235qcRvn3pQKKbPjYTrxdiiC"
    //     };
    //     var result = await apiClient.GetAccountTransportExport(request);
    //
    //     // Assert
    //     Assert.Multiple(() =>
    //     {
    //         Assert.That(result, Is.Not.Null);
    //         Assert.That(result.Success, Is.True);
    //         Assert.That(result.Data, Is.Not.Null);
    //         Assert.That(result.Data.Account, Is.EqualTo("2YcwVbKx9L25Jpaj2vfWSXD5UKugZumWjzEe6suBUJi2"));
    //         Assert.That(result.Data.Lamports, Is.EqualTo(11934280));
    //         Assert.That(result.Data.Type, Is.EqualTo("system_account"));
    //         Assert.That(result.Data.Executable, Is.EqualTo(false));
    //         Assert.That(result.Data.OwnerProgram, Is.EqualTo("11111111111111111111111111111111"));
    //         Assert.That(result.Data.RentEpoch, Is.EqualTo(BigInteger.Parse("18446744073709552000")));
    //         Assert.That(result.Data.IsOncurve, Is.EqualTo(true));
    //     });
    // }

    #endregion

    #region Token APIs

    #endregion

    #region NFT APIs

    #endregion

    #region Transaction APIs

    [Test]
    public async Task GetLastTransactions_WithValidRequest_ReturnsAccountTransfer()
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
                                              "slot": 282493339,
                                              "fee": 5400,
                                              "status": "Success",
                                              "signer": [
                                                "28FBsXoAH8BPy8RT7RZtb8SMoJUVCPWVtZMeskxe6sPg"
                                              ],
                                              "block_time": 1723194084,
                                              "tx_hash": "61zYZzrAR5HAdXyg41QpjoaZxL79aunWUhfxBtcSNGC6s11eHyTKCb3au6wNad1JddMAbATKTgoWPnooqeebc7KV",
                                              "parsed_instructions": [
                                                {
                                                  "type": "addProduct",
                                                  "program": "Pyth",
                                                  "program_id": "FsJ3A3u2vn5cTVofAjvy6y5kwABJAqYWpe4975bi2epH"
                                                },
                                                {
                                                  "type": "addProduct",
                                                  "program": "Pyth",
                                                  "program_id": "FsJ3A3u2vn5cTVofAjvy6y5kwABJAqYWpe4975bi2epH"
                                                },
                                                {
                                                  "type": "addProduct",
                                                  "program": "Pyth",
                                                  "program_id": "FsJ3A3u2vn5cTVofAjvy6y5kwABJAqYWpe4975bi2epH"
                                                },
                                                {
                                                  "type": "addProduct",
                                                  "program": "Pyth",
                                                  "program_id": "FsJ3A3u2vn5cTVofAjvy6y5kwABJAqYWpe4975bi2epH"
                                                },
                                                {
                                                  "type": "addProduct",
                                                  "program": "Pyth",
                                                  "program_id": "FsJ3A3u2vn5cTVofAjvy6y5kwABJAqYWpe4975bi2epH"
                                                },
                                                {
                                                  "type": "addProduct",
                                                  "program": "Pyth",
                                                  "program_id": "FsJ3A3u2vn5cTVofAjvy6y5kwABJAqYWpe4975bi2epH"
                                                },
                                                {
                                                  "type": "addProduct",
                                                  "program": "Pyth",
                                                  "program_id": "FsJ3A3u2vn5cTVofAjvy6y5kwABJAqYWpe4975bi2epH"
                                                },
                                                {
                                                  "type": "addProduct",
                                                  "program": "Pyth",
                                                  "program_id": "FsJ3A3u2vn5cTVofAjvy6y5kwABJAqYWpe4975bi2epH"
                                                },
                                                {
                                                  "type": "addProduct",
                                                  "program": "Pyth",
                                                  "program_id": "FsJ3A3u2vn5cTVofAjvy6y5kwABJAqYWpe4975bi2epH"
                                                },
                                                {
                                                  "type": "addProduct",
                                                  "program": "Pyth",
                                                  "program_id": "FsJ3A3u2vn5cTVofAjvy6y5kwABJAqYWpe4975bi2epH"
                                                }
                                              ],
                                              "program_ids": [
                                                "FsJ3A3u2vn5cTVofAjvy6y5kwABJAqYWpe4975bi2epH",
                                                "ComputeBudget111111111111111111111111111111"
                                              ],
                                              "time": "2024-08-09T09:01:24.000Z"
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
                    "https://pro-api.solscan.io/v2.0/transaction/last?limit=60&filter=exceptVote")));
            return Task.FromResult(fakeResponse);
        });

        var httpClient = new HttpClient(handler);
        var apiClient = new SolscanClient("", httpClient);

        // Act
        var request = new LastTransactionsRequest
        {
            Filter = EFilter.ExceptVote,
            Limit = ELimit.Sixty,
        };
        var result = await apiClient.GetLastTransactions(request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Empty);
            Assert.That(result.Data[0].Slot, Is.EqualTo(282493339));
            Assert.That(result.Data[0].Fee, Is.EqualTo(5400));
            Assert.That(result.Data[0].Status, Is.EqualTo("Success"));
            Assert.That(result.Data[0].Signer, Is.EqualTo(["28FBsXoAH8BPy8RT7RZtb8SMoJUVCPWVtZMeskxe6sPg"]));
            Assert.That(result.Data[0].BlockTime, Is.EqualTo(1723194084));
            Assert.That(result.Data[0].TxHash,
                Is.EqualTo("61zYZzrAR5HAdXyg41QpjoaZxL79aunWUhfxBtcSNGC6s11eHyTKCb3au6wNad1JddMAbATKTgoWPnooqeebc7KV"));
            Assert.That(result.Data[0].ParsedInstructions, Has.Count.EqualTo(10));
            Assert.That(result.Data[0].ProgramIds, Is.EqualTo([
                "FsJ3A3u2vn5cTVofAjvy6y5kwABJAqYWpe4975bi2epH",
                "ComputeBudget111111111111111111111111111111"
            ]));
            Assert.That(result.Data[0].Time.ToUniversalTime(),
                Is.EqualTo(DateTime.Parse("2024-08-09T09:01:24.000Z").ToUniversalTime()));
        });
    }

    [Test]
    public async Task GetLastTransactions_WithBadRequest_ReturnsAccountTransfer()
    {
        // Arrange
        var fakeResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.BadRequest,
            Content = new StringContent("""
                                        {
                                          "success": false,
                                          "errors": {
                                            "code": 1100,
                                            "message": "Validation Error: tx is not allowed"
                                          }
                                        }
                                        """)
        };

        var handler = new TestHttpMessageHandler((request, cancellationToken) =>
        {
            Assert.That(request.Method, Is.EqualTo(HttpMethod.Get));
            Assert.That(request.RequestUri,
                Is.EqualTo(new Uri(
                    "https://pro-api.solscan.io/v2.0/transaction/last?limit=60&filter=exceptVote")));
            return Task.FromResult(fakeResponse);
        });

        var httpClient = new HttpClient(handler);
        var apiClient = new SolscanClient("", httpClient);

        // Act
        var request = new LastTransactionsRequest
        {
            Filter = EFilter.ExceptVote,
            Limit = ELimit.Sixty,
        };
        var result = await apiClient.GetLastTransactions(request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Data, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error!.Code, Is.EqualTo(1100));
            Assert.That(result.Error!.Message, Is.EqualTo("Validation Error: tx is not allowed"));
        });
    }
    
    [Test]
    public async Task GetLastTransactions_WithAuthenticationFailed_ReturnsAccountTransfer()
    {
        // Arrange
        var httpClient = new HttpClient();
        var apiClient = new SolscanClient("INVALID-API-KEY", httpClient);

        // Act
        var request = new LastTransactionsRequest
        {
            Filter = EFilter.ExceptVote,
            Limit = ELimit.Sixty,
        };
        AsyncTestDelegate testDelegate = async () => await apiClient.GetLastTransactions(request);

        // Assert
        var exception = Assert.ThrowsAsync<HttpRequestException>(testDelegate);
        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [Test]
    public async Task GetTransactionDetails_WithValidRequest_ReturnsAccountTransfer()
    {
        // Arrange
        var fakeResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("""
                                        {
                                          "success": true,
                                          "data": {
                                            "block_id": 310830160,
                                            "fee": 5000,
                                            "reward": [],
                                            "sol_bal_change": [
                                              {
                                                "address": "JD1dHSqYkrXvqUVL8s6gzL1yB7kpYymsHfwsGxgwp55h",
                                                "pre_balance": "65818866229",
                                                "post_balance": "65818821229",
                                                "change_amount": "-45000"
                                              },
                                              {
                                                "address": "Cw8CFyM9FkoMi7K7Crf6HNQqf4uEMzpKw6QNghXLvLkY",
                                                "pre_balance": "103715668",
                                                "post_balance": "103755668",
                                                "change_amount": "40000"
                                              },
                                              {
                                                "address": "11111111111111111111111111111111",
                                                "pre_balance": "1",
                                                "post_balance": "1",
                                                "change_amount": "0"
                                              }
                                            ],
                                            "token_bal_change": [],
                                            "tokens_involved": [],
                                            "parsed_instructions": [
                                              {
                                                "ins_index": 0,
                                                "parsed_type": "transfer",
                                                "type": "transfer",
                                                "program_id": "11111111111111111111111111111111",
                                                "program": "system",
                                                "outer_program_id": null,
                                                "outer_ins_index": -1,
                                                "data_raw": {
                                                  "info": {
                                                    "destination": "Cw8CFyM9FkoMi7K7Crf6HNQqf4uEMzpKw6QNghXLvLkY",
                                                    "lamports": 40000,
                                                    "source": "JD1dHSqYkrXvqUVL8s6gzL1yB7kpYymsHfwsGxgwp55h"
                                                  },
                                                  "type": "transfer"
                                                },
                                                "accounts": [],
                                                "activities": [],
                                                "transfers": [
                                                  {
                                                    "source_owner": "JD1dHSqYkrXvqUVL8s6gzL1yB7kpYymsHfwsGxgwp55h",
                                                    "source": "JD1dHSqYkrXvqUVL8s6gzL1yB7kpYymsHfwsGxgwp55h",
                                                    "destination": "Cw8CFyM9FkoMi7K7Crf6HNQqf4uEMzpKw6QNghXLvLkY",
                                                    "destination_owner": "Cw8CFyM9FkoMi7K7Crf6HNQqf4uEMzpKw6QNghXLvLkY",
                                                    "transfer_type": "spl_transfer",
                                                    "token_address": "So11111111111111111111111111111111111111111",
                                                    "decimals": 9,
                                                    "amount_str": "40000",
                                                    "amount": 40000,
                                                    "program_id": "11111111111111111111111111111111",
                                                    "outer_program_id": null,
                                                    "ins_index": 0,
                                                    "outer_ins_index": -1,
                                                    "event": "",
                                                    "fee": {}
                                                  }
                                                ],
                                                "program_invoke_level": 1
                                              }
                                            ],
                                            "programs_involved": [
                                              "11111111111111111111111111111111"
                                            ],
                                            "signer": [
                                              "JD1dHSqYkrXvqUVL8s6gzL1yB7kpYymsHfwsGxgwp55h"
                                            ],
                                            "list_signer": [
                                              "JD1dHSqYkrXvqUVL8s6gzL1yB7kpYymsHfwsGxgwp55h"
                                            ],
                                            "status": 1,
                                            "account_keys": [
                                              {
                                                "pubkey": "JD1dHSqYkrXvqUVL8s6gzL1yB7kpYymsHfwsGxgwp55h",
                                                "signer": true,
                                                "source": "transaction",
                                                "writable": true
                                              },
                                              {
                                                "pubkey": "Cw8CFyM9FkoMi7K7Crf6HNQqf4uEMzpKw6QNghXLvLkY",
                                                "signer": false,
                                                "source": "transaction",
                                                "writable": true
                                              },
                                              {
                                                "pubkey": "11111111111111111111111111111111",
                                                "signer": false,
                                                "source": "transaction",
                                                "writable": false
                                              }
                                            ],
                                            "compute_units_consumed": 150,
                                            "confirmations": null,
                                            "version": 0,
                                            "tx_hash": "3xRGzAqsto9RujZUKNXrLRASTiER2GnWi4Z41vHbpBHxT26HdeCKFD5LZx7D2KiSJuAhdiuzZv7Sw2kaAXAiiYh3",
                                            "block_time": 1735586811,
                                            "address_table_lookup": [],
                                            "log_message": [
                                              "Program 11111111111111111111111111111111 invoke [1]",
                                              "Program 11111111111111111111111111111111 success"
                                            ],
                                            "recent_block_hash": "Bx9oCcBDXb1nZ1RHj6Yjb8oUv7rf95wmJpWWuuFEd6a9",
                                            "tx_status": "finalized"
                                          },
                                          "metadata": {}
                                        }
                                        """)
        };

        var handler = new TestHttpMessageHandler((request, cancellationToken) =>
        {
            Assert.That(request.Method, Is.EqualTo(HttpMethod.Get));
            Assert.That(request.RequestUri,
                Is.EqualTo(new Uri(
                    "https://pro-api.solscan.io/v2.0/transaction/detail?tx=3xRGzAqsto9RujZUKNXrLRASTiER2GnWi4Z41vHbpBHxT26HdeCKFD5LZx7D2KiSJuAhdiuzZv7Sw2kaAXAiiYh3")));
            return Task.FromResult(fakeResponse);
        });

        var httpClient = new HttpClient(handler);
        var apiClient = new SolscanClient("", httpClient);

        // Act
        var request = new TransactionDetailsRequest
        {
            Tx = "3xRGzAqsto9RujZUKNXrLRASTiER2GnWi4Z41vHbpBHxT26HdeCKFD5LZx7D2KiSJuAhdiuzZv7Sw2kaAXAiiYh3"
        };
        var result = await apiClient.GetTransactionDetails(request);

       // Assert
    Assert.Multiple(() =>
    {
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Success, Is.True);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data.BlockId, Is.EqualTo(310830160));
        Assert.That(result.Data.Fee, Is.EqualTo(5000));
        Assert.That(result.Data.Reward, Is.Empty);
        Assert.That(result.Data.SolBalChange, Is.Not.Empty);
        Assert.That(result.Data.SolBalChange[0].Address,
            Is.EqualTo("JD1dHSqYkrXvqUVL8s6gzL1yB7kpYymsHfwsGxgwp55h"));
        Assert.That(result.Data.SolBalChange[0].PreBalance, Is.EqualTo("65818866229"));
        Assert.That(result.Data.SolBalChange[0].PostBalance, Is.EqualTo("65818821229"));
        Assert.That(result.Data.SolBalChange[0].ChangeAmount, Is.EqualTo("-45000"));

        Assert.That(result.Data.SolBalChange[1].Address,
            Is.EqualTo("Cw8CFyM9FkoMi7K7Crf6HNQqf4uEMzpKw6QNghXLvLkY"));
        Assert.That(result.Data.SolBalChange[1].PreBalance, Is.EqualTo("103715668"));
        Assert.That(result.Data.SolBalChange[1].PostBalance, Is.EqualTo("103755668"));
        Assert.That(result.Data.SolBalChange[1].ChangeAmount, Is.EqualTo("40000"));

        Assert.That(result.Data.SolBalChange[2].Address, Is.EqualTo("11111111111111111111111111111111"));
        Assert.That(result.Data.SolBalChange[2].PreBalance, Is.EqualTo("1"));
        Assert.That(result.Data.SolBalChange[2].PostBalance, Is.EqualTo("1"));
        Assert.That(result.Data.SolBalChange[2].ChangeAmount, Is.EqualTo("0"));

        Assert.That(result.Data.TokenBalChange, Is.Empty);
        Assert.That(result.Data.TokensInvolved, Is.Empty);

        // Verify the single parsed instruction
        Assert.That(result.Data.ParsedInstructions, Has.Count.EqualTo(1));
        var instruction = result.Data.ParsedInstructions[0];
        Assert.That(instruction.InsIndex, Is.EqualTo(0));
        Assert.That(instruction.ParsedType, Is.EqualTo("transfer"));
        Assert.That(instruction.Type, Is.EqualTo("transfer"));
        Assert.That(instruction.ProgramId, Is.EqualTo("11111111111111111111111111111111"));
        Assert.That(instruction.Program, Is.EqualTo("system"));
        Assert.That(instruction.OuterProgramId, Is.Null);
        Assert.That(instruction.OuterInsIndex, Is.EqualTo(-1));
        Assert.That(instruction.ProgramInvokeLevel, Is.EqualTo(1));

        // Verify the transfers within this instruction
        Assert.That(instruction.Transfers, Has.Count.EqualTo(1));
        var transfer = instruction.Transfers[0];
        Assert.That(transfer.SourceOwner, Is.EqualTo("JD1dHSqYkrXvqUVL8s6gzL1yB7kpYymsHfwsGxgwp55h"));
        Assert.That(transfer.Source, Is.EqualTo("JD1dHSqYkrXvqUVL8s6gzL1yB7kpYymsHfwsGxgwp55h"));
        Assert.That(transfer.Destination, Is.EqualTo("Cw8CFyM9FkoMi7K7Crf6HNQqf4uEMzpKw6QNghXLvLkY"));
        Assert.That(transfer.DestinationOwner, Is.EqualTo("Cw8CFyM9FkoMi7K7Crf6HNQqf4uEMzpKw6QNghXLvLkY"));
        Assert.That(transfer.TransferType, Is.EqualTo("spl_transfer"));
        Assert.That(transfer.TokenAddress, Is.EqualTo("So11111111111111111111111111111111111111111"));
        Assert.That(transfer.Decimals, Is.EqualTo(9));
        Assert.That(transfer.AmountStr, Is.EqualTo("40000"));
        Assert.That(transfer.Amount, Is.EqualTo(40000));
        Assert.That(transfer.ProgramId, Is.EqualTo("11111111111111111111111111111111"));
        Assert.That(transfer.OuterProgramId, Is.Null);
        Assert.That(transfer.InsIndex, Is.EqualTo(0));
        Assert.That(transfer.OuterInsIndex, Is.EqualTo(-1));
        Assert.That(transfer.Event, Is.EqualTo(""));

        Assert.That(result.Data.ComputeUnitsConsumed, Is.EqualTo(150));
        Assert.That(result.Data.Confirmations, Is.Null);
        Assert.That(result.Data.Version, Is.EqualTo(0));
        Assert.That(result.Data.TxHash,
            Is.EqualTo("3xRGzAqsto9RujZUKNXrLRASTiER2GnWi4Z41vHbpBHxT26HdeCKFD5LZx7D2KiSJuAhdiuzZv7Sw2kaAXAiiYh3"));
        Assert.That(result.Data.BlockTime, Is.EqualTo(1735586811));
        Assert.That(result.Data.AddressTableLookup, Is.Empty);
        Assert.That(result.Data.LogMessage, Is.EqualTo(new[]
        {
            "Program 11111111111111111111111111111111 invoke [1]",
            "Program 11111111111111111111111111111111 success"
        }));
        Assert.That(result.Data.RecentBlockHash, Is.EqualTo("Bx9oCcBDXb1nZ1RHj6Yjb8oUv7rf95wmJpWWuuFEd6a9"));
        Assert.That(result.Data.TxStatus, Is.EqualTo("finalized"));
    });
    }

    #endregion

    #region Block APIs



    #endregion

    #region Monitoring APIs



    #endregion

    #region Market APIs

    [Test]
    public async Task GetPoolMarketList_WithValidRequest_ReturnsAccountTransfer()
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
                                              "pool_address": "FpCMFDFGYotvufJ7HrFHsWEiiQCGbkLCtwHiDnh7o28Q",
                                              "program_id": "whirLbMiicVdio4qvUfM5KAg6Ct8VwpYzGff3uctyCc",
                                              "token1": "So11111111111111111111111111111111111111112",
                                              "token1_account": "6mQ8xEaHdTikyMvvMxUctYch6dUjnKgfoeib2msyMMi1",
                                              "token2": "EPjFWdd5AufqSSqeM2qN1xzybapC8G4wEGGkZwyTDt1v",
                                              "token2_account": "AQ36QRk3HAe6PHqBCtKTQnYKpt2kAagq9YoeTqUPMGHx",
                                              "total_volume_24h": 6715996,
                                              "total_trade_24h": 25377,
                                              "created_time": 1719792010
                                            },
                                            {
                                              "pool_address": "4eJ1jCPysCrEH53VUAxgNT8BMccXsgHX1nX4FxXAUVWy",
                                              "program_id": "whirLbMiicVdio4qvUfM5KAg6Ct8VwpYzGff3uctyCc",
                                              "token1": "USDH1SM1ojwWUga67PGrgFWUHibbjqMvuMaDkRJTgkX",
                                              "token1_account": "2ads2xeSdmHNV8BAbZgcyPr2q1AJ24KfCZ3WNEgV25x3",
                                              "token2": "mSoLzYCxHdYgdzU16g5QSh3i5K3z3KZK7ytfqcJm7So",
                                              "token2_account": "CEtPaTBXmn2zDEx1w2xt12ZxfcKWLBKzumeHCFNSuCmW",
                                              "total_volume_24h": 956,
                                              "total_trade_24h": 62,
                                              "created_time": 1719792011
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
                    "https://pro-api.solscan.io/v2.0/market/list?program=83Jy6CBGbueazwrEDGpzoMnbyVyoZQLEL6ZKVXKXmZUw&page=1337&page_size=20&sort_by=created_time&sort_order=desc")));
            return Task.FromResult(fakeResponse);
        });

        var httpClient = new HttpClient(handler);
        var apiClient = new SolscanClient("", httpClient);

        // Act
        var request = new PoolMarketListRequest
        {
            ProgramAddress = "83Jy6CBGbueazwrEDGpzoMnbyVyoZQLEL6ZKVXKXmZUw",
            PageSize = 20,
            Page = 1337,
            SortOrder = ESortOrder.Descending,
            SortBy = EPoolSortBy.CreatedTime,
        };
        var result = await apiClient.GetPoolMarketList(request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Empty);
            Assert.That(result.Data[0].PoolAddress, Is.EqualTo("FpCMFDFGYotvufJ7HrFHsWEiiQCGbkLCtwHiDnh7o28Q"));
            Assert.That(result.Data[0].ProgramId, Is.EqualTo("whirLbMiicVdio4qvUfM5KAg6Ct8VwpYzGff3uctyCc"));
            Assert.That(result.Data[0].Token1, Is.EqualTo("So11111111111111111111111111111111111111112"));
            Assert.That(result.Data[0].Token1Account, Is.EqualTo("6mQ8xEaHdTikyMvvMxUctYch6dUjnKgfoeib2msyMMi1"));
            Assert.That(result.Data[0].Token2, Is.EqualTo("EPjFWdd5AufqSSqeM2qN1xzybapC8G4wEGGkZwyTDt1v"));
            Assert.That(result.Data[0].Token2Account, Is.EqualTo("AQ36QRk3HAe6PHqBCtKTQnYKpt2kAagq9YoeTqUPMGHx"));
            Assert.That(result.Data[0].TotalVolume24h, Is.EqualTo(6715996));
            Assert.That(result.Data[0].TotalTrade24h, Is.EqualTo(25377));
            Assert.That(result.Data[0].CreatedTime, Is.EqualTo(1719792010));
        });
    }
    
    [Test]
    public async Task GetMarketInfo_WithValidRequest_ReturnsAccountTransfer()
    {
        // Arrange
        var fakeResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("""
                                        {
                                          "success": true,
                                          "data": {
                                            "pool_address": "7eexH14UjhNxJe6zTT3f1Vb1E8iACsBMVaWheDEmxdT2",
                                            "program_id": "LBUZKhRxPF3XUpBCjp4YzTKgLccjZhTSDM9YuVaPwxo",
                                            "token1": "DezXAZ8z7PnrnRJjz3wXBoRgixCa6xjnB7YaB1pPB263",
                                            "token2": "So11111111111111111111111111111111111111112",
                                            "token1_account": "77MR2zLM2BQNbZhQDMx82SgRcx2vQumfMQLLfPrSio8k",
                                            "token2_account": "9iKvd5kvcFGKAHx489rcBS3sX8nSTsouLFBvQirwNhGG",
                                            "token1_amount": 2884919764.07666,
                                            "token2_amount": 11135.14329621
                                          }
                                        }
                                        """)
        };

        var handler = new TestHttpMessageHandler((request, cancellationToken) =>
        {
            Assert.That(request.Method, Is.EqualTo(HttpMethod.Get));
            Assert.That(request.RequestUri,
                Is.EqualTo(new Uri(
                    "https://pro-api.solscan.io/v2.0/market/info?address=83Jy6CBGbueazwrEDGpzoMnbyVyoZQLEL6ZKVXKXmZUw")));
            return Task.FromResult(fakeResponse);
        });

        var httpClient = new HttpClient(handler);
        var apiClient = new SolscanClient("", httpClient);

        // Act
        var request = new MarketInfoRequest
        {
            Address = "83Jy6CBGbueazwrEDGpzoMnbyVyoZQLEL6ZKVXKXmZUw"
        };
        var result = await apiClient.GetMarketInfo(request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.PoolAddress, Is.EqualTo("7eexH14UjhNxJe6zTT3f1Vb1E8iACsBMVaWheDEmxdT2"));
            Assert.That(result.Data.ProgramId, Is.EqualTo("LBUZKhRxPF3XUpBCjp4YzTKgLccjZhTSDM9YuVaPwxo"));
            Assert.That(result.Data.Token1, Is.EqualTo("DezXAZ8z7PnrnRJjz3wXBoRgixCa6xjnB7YaB1pPB263"));
            Assert.That(result.Data.Token1Account, Is.EqualTo("77MR2zLM2BQNbZhQDMx82SgRcx2vQumfMQLLfPrSio8k"));
            Assert.That(result.Data.Token1Amount, Is.EqualTo(2884919764.07666));
            Assert.That(result.Data.Token2, Is.EqualTo("So11111111111111111111111111111111111111112"));
            Assert.That(result.Data.Token2Account, Is.EqualTo("9iKvd5kvcFGKAHx489rcBS3sX8nSTsouLFBvQirwNhGG"));
            Assert.That(result.Data.Token2Amount, Is.EqualTo(11135.14329621));
        });
    }

    [Test]
    public async Task GetMarketVolume_WithValidRequest_ReturnsAccountTransfer()
    {
        // Arrange
        var fakeResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("""
                                        {
                                          "success": true,
                                          "data": {
                                            "pool_address": "7eexH14UjhNxJe6zTT3f1Vb1E8iACsBMVaWheDEmxdT2",
                                            "program_id": "LBUZKhRxPF3XUpBCjp4YzTKgLccjZhTSDM9YuVaPwxo",
                                            "total_volume_24h": 2212179,
                                            "total_volume_change_24h": -38.36077460277853,
                                            "total_trades_24h": 4124,
                                            "total_trades_change_24h": -31.01357904946654,
                                            "days": [
                                              {
                                                "day": 20241114,
                                                "value": 2069898
                                              },
                                              {
                                                "day": 20241115,
                                                "value": 1765762
                                              }
                                            ]
                                          }
                                        }
                                        """)
        };

        var handler = new TestHttpMessageHandler((request, cancellationToken) =>
        {
            Assert.That(request.Method, Is.EqualTo(HttpMethod.Get));
            Assert.That(request.RequestUri,
                Is.EqualTo(new Uri(
                    "https://pro-api.solscan.io/v2.0/market/volume?address=83Jy6CBGbueazwrEDGpzoMnbyVyoZQLEL6ZKVXKXmZUw&time[]=20240701&time[]=20240715")));
            return Task.FromResult(fakeResponse);
        });

        var httpClient = new HttpClient(handler);
        var apiClient = new SolscanClient("", httpClient);

        // Act
        var request = new MarketVolumeRequest
        {
            Address = "83Jy6CBGbueazwrEDGpzoMnbyVyoZQLEL6ZKVXKXmZUw",
            Times = [
                DateTime.ParseExact("20240701", "yyyyMMdd", null),
                DateTime.ParseExact("20240715", "yyyyMMdd", null),
            ]
        };
        var result = await apiClient.GetMarketVolume(request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.PoolAddress, Is.EqualTo("7eexH14UjhNxJe6zTT3f1Vb1E8iACsBMVaWheDEmxdT2"));
            Assert.That(result.Data.ProgramId, Is.EqualTo("LBUZKhRxPF3XUpBCjp4YzTKgLccjZhTSDM9YuVaPwxo"));
            Assert.That(result.Data.TotalVolume24h, Is.EqualTo(2212179));
            Assert.That(result.Data.TotalVolumeChange24h, Is.EqualTo(-38.36077460277853));
            Assert.That(result.Data.TotalTrades24h, Is.EqualTo(4124));
            Assert.That(result.Data.TotalTradesChange24h, Is.EqualTo(-31.01357904946654));
            Assert.That(result.Data.Days, Has.Count.EqualTo(2));
            Assert.That(result.Data.Days[0].Day, Is.EqualTo(20241114));
            Assert.That(result.Data.Days[0].Value, Is.EqualTo(2069898));
            Assert.That(result.Data.Days[1].Day, Is.EqualTo(20241115));
            Assert.That(result.Data.Days[1].Value, Is.EqualTo(1765762));
        });
    }
    
    #endregion
}