namespace SolScanner.Requests;

public sealed class NftActivitiesRequest : BaseRequest
{
    public override string GetUrl()
    {
        return new UrlBuilder()
            .WithBaseUrl("https://pro-api.solscan.io/v2.0/nft/activities")
            .WithFrom(From)
            .WithTo(To)
            .WithSourceAddresses(Source)
            .WithActivityTypes(ActivityTypes)
            .WithToken(Token)
            .WithCollection(Collection)
            .WithCurrencyToken(CurrencyToken)
            .WithPrices(Prices)
            .WithBlockTimes(BlockTimes)
            .WithPage(Page)
            .WithPageSize(PageSize)
            .Build();
    }


    public string From { get; set; }

    public string To { get; set; }

    /// <summary>
    /// Filter by list source addresses. Maximum 5 addresses
    /// </summary>
    public string[] Source { get; set; }

    public ENftActivityType ActivityTypes { get; set; }

    /// <summary>
    /// Filter activities data by token address
    /// </summary>
    public string Token { get; set; }
    
    /// <summary>
    /// collection
    /// </summary>
    public string Collection { get; set; }
    public string CurrencyToken { get; set; }

    /// <summary>
    /// Filter transfer data by by amount. But you need to pass token address in field currency_token first because price filter will be belong to one currency token address. Ex: Filter price from 1 to 2 SOL
    /// </summary>
    public uint[] Prices { get; set; } = [];

    /// <summary>
    /// Used when you want to filter data by block time. Format time: UnixTime in seconds. You need to pass array into http query to filter by start and stop block_time.
    /// </summary>
    public uint[] BlockTimes { get; set; } = [];

    /// <summary>
    /// Page number for pagination
    /// </summary>
    public uint Page { get; set; }

    /// <summary>
    /// Number items per page. Valid values: 10, 20, 30, 40, 60, 100
    /// </summary>
    public uint PageSize { get; set; }
}