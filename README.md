# SolScanner


[![NuGet version (BscScanner)](https://img.shields.io/github/actions/workflow/status/pippinmole/solscanner/test-ci.yml)](https://www.nuget.org/packages/SolScanner)
[![NuGet downloads (SolScanner)](https://img.shields.io/nuget/dt/SolScanner)](https://www.nuget.org/packages/SolScanner)

SolScanner is a .NET wrapper for the [SolScan API](https://pro-api.solscan.io/pro-api-docs/v2.0).

> [!IMPORTANT]  
> This project is in active development. It is also GUESS WORK as I do not have access to a PRO Solscan API key. If you would like to help, please create a GitHub issue with your contact information.


### How to use

1. Install the [Nuget](https://www.nuget.org/packages/SolScanner) package
    ```cli
    Install-Package SolScanner
    ```
2. Instantiate the BscScanClient
    ```cs
    var apiKey = "...";
    var client = new SolscanClient(apiKey);
    var request = new AccountTransactionsRequest
    {
        Address = "GCUEeFgWWcAouA8KvXbY235qcRvn3pQKKbPjYTrxdiiC",
        Before = "2HY1yJ54GHRDR1jGLKQMi4xNR4cx488xeHK87z4Lh16c",
        Limit = ELimit.Fourty,
    };
    
    var result = await client.GetAccountTransactions(request);
    
    if(result.Success) {
        // Do successful things
    } else {
        // :(
    }
    ```

## How to contribute

You can contribute by pulling the code, making some changes and then opening a pull request. The changes will be revised and merged into main if it is a valid feature/bug fix.

1. Pull the latest main branch
2. Nuget restore to get dependencies
3. Make some changes
4. Create a pull request with a detailed explanation on why the changes were made

You can also donate SOL to this address: 5HMZmbtYm8KY5Zyjr7cy7C4WemEJyP4AqWksaJrUHHmG