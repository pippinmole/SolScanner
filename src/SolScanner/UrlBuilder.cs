using System;
using System.Collections.Generic;
using System.Linq;
using SolScanner.Requests;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace SolScanner;

public sealed class UrlBuilder
{
    private string _baseUrl;
    private string _address;
    private readonly List<string> _activityTypes = [];
    private string _tokenAccount;
    private string _from;
    private string _to;
    private string _token;
    private readonly List<uint> _amounts = [];
    private readonly List<uint> _blockTimes = [];
    private bool? _excludeAmountZero;
    private string _flow;
    private uint _page;
    private uint _pageSize;
    private string _sortBy;
    private string _sortOrder;
    private string _tokenType;
    private bool? _hideZero;
    private string[] _platforms = [];
    private string[] _sourceAddresses = [];
    private string _before;
    private string _limit;
    private bool? _removeSpam;
    private uint _timeFrom;
    private uint _timeTo;
    private string _programAddress;
    private List<string> _times = [];
    private uint _blockNumber;
    private string _filter;
    private string _tx;

    public UrlBuilder WithBaseUrl(string baseUrl)
    {
        _baseUrl = baseUrl;
        return this;
    }

    public UrlBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }

    public UrlBuilder WithActivityTypes(params EActivityType[] activityTypes)
    {
        _activityTypes.AddRange(activityTypes.Select(x => x.ToString()));
        return this;
    }

    public UrlBuilder WithActivityTypes(params EDefiActivityType[] activityTypes)
    {
        _activityTypes.AddRange(activityTypes.Select(x => x.ToString()));
        return this;
    }

    public UrlBuilder WithTokenAccount(string tokenAccount)
    {
        _tokenAccount = tokenAccount;
        return this;
    }

    public UrlBuilder WithFrom(string from)
    {
        _from = from;
        return this;
    }

    public UrlBuilder WithTo(string to)
    {
        _to = to;
        return this;
    }

    public UrlBuilder WithToken(string token)
    {
        _token = token;
        return this;
    }

    public UrlBuilder WithAmounts(params uint[] amounts)
    {
        _amounts.AddRange(amounts);
        return this;
    }

    public UrlBuilder WithBlockTimes(params uint[] blockTimes)
    {
        _blockTimes.AddRange(blockTimes);
        return this;
    }

    public UrlBuilder ExcludeAmountZero(bool exclude)
    {
        _excludeAmountZero = exclude;
        return this;
    }

    public UrlBuilder WithFlow(EFlow flow)
    {
        _flow = flow switch
        {
            EFlow.In => "in",
            EFlow.Out => "out",
            _ => throw new ArgumentOutOfRangeException(nameof(flow), flow, null)
        };
        return this;
    }

    public UrlBuilder WithPage(uint page)
    {
        _page = page;
        return this;
    }

    public UrlBuilder WithPageSize(uint pageSize)
    {
        _pageSize = pageSize;
        return this;
    }

    public UrlBuilder WithSortBy(string sortBy)
    {
        _sortBy = sortBy;
        return this;
    }

    public UrlBuilder WithSortOrder(ESortOrder sortOrder)
    {
        _sortOrder = sortOrder switch
        {
            ESortOrder.Ascending => "asc",
            ESortOrder.Descending => "desc",
            _ => throw new ArgumentOutOfRangeException(nameof(sortOrder), sortOrder, null)
        };

        return this;
    }

    public UrlBuilder WithSortBy(EPoolSortBy sortBy)
    {
        _sortBy = sortBy switch
        {
            EPoolSortBy.CreatedTime => "created_time",
            _ => throw new ArgumentOutOfRangeException(nameof(sortBy), sortBy, null)
        };
        return this;
    }

    public UrlBuilder WithSortOrder(string sortOrder)
    {
        _sortOrder = sortOrder;
        return this;
    }

    public UrlBuilder WithTokenType(ETokenType tokenType)
    {
        _tokenType = tokenType.ToString();
        return this;
    }

    public UrlBuilder WithHideZero(bool hideZero)
    {
        _hideZero = hideZero;
        return this;
    }

    public UrlBuilder WithPlatforms(string[] platforms)
    {
        _platforms = platforms;
        return this;
    }

    public UrlBuilder WithBefore(string before)
    {
        _before = before;
        return this;
    }

    public UrlBuilder WithLimit(ELimit limit)
    {
        _limit = limit switch
        {
            ELimit.Ten => "10",
            ELimit.Twenty => "20",
            ELimit.Thirty => "30",
            ELimit.Fourty => "40",
            ELimit.Fifty => "50",
            ELimit.Sixty => "60",
            ELimit.Seventy => "70",
            ELimit.Eighty => "80",
            ELimit.Ninety => "90",
            ELimit.OneHundred => "100",
            _ => throw new ArgumentOutOfRangeException(nameof(limit), limit, null)
        };

        return this;
    }

    public UrlBuilder WithSourceAddresses(string[] sources)
    {
        _sourceAddresses = sources;
        return this;
    }

    public UrlBuilder WithRemoveSpam(bool removeSpam)
    {
        _removeSpam = removeSpam;
        return this;
    }

    public UrlBuilder WithTimeFrom(uint timeFrom)
    {
        _timeFrom = timeFrom;
        return this;
    }

    public UrlBuilder WithTimeTo(uint timeTo)
    {
        _timeTo = timeTo;
        return this;
    }

    public UrlBuilder WithProgramAddress(string programAddress)
    {
        _programAddress = programAddress;
        return this;
    }

    public UrlBuilder WithTimes(DateTime[] times)
    {
        _times = times.Select(x => x.ToString("yyyyMMdd")).ToList();
        return this;
    }

    public UrlBuilder WithBlock(uint blockNumber)
    {
        _blockNumber = blockNumber;
        return this;
    }

    public UrlBuilder WithFilter(EFilter filter)
    {
        _filter = filter switch
        {
            EFilter.ExceptVote => "exceptVote",
            EFilter.All => "all",
            _ => throw new ArgumentOutOfRangeException(nameof(filter), filter, null)
        };
        return this;
    }

    public UrlBuilder WithTx(string tx)
    {
        _tx = tx;
        return this;
    }

    public string Build()
    {
        if (string.IsNullOrEmpty(_baseUrl))
            throw new InvalidOperationException("Base URL must be set.");

        var query = new List<string>();

        if (!string.IsNullOrEmpty(_address))
            query.Add($"address={_address}");

        foreach (var platform in _platforms)
            query.Add($"platform[]={platform}");

        foreach (var sourceAddress in _sourceAddresses)
            query.Add($"source[]={sourceAddress}");

        if (!string.IsNullOrEmpty(_before))
            query.Add($"before={_before}");

        if (!string.IsNullOrEmpty(_limit))
            query.Add($"limit={_limit}");

        if (!string.IsNullOrEmpty(_tx))
            query.Add($"tx={_tx}");

        if (!string.IsNullOrEmpty(_programAddress))
            query.Add($"program={_programAddress}");

        foreach (var activityType in _activityTypes)
            query.Add($"activity_type[]={activityType}");

        if (!string.IsNullOrEmpty(_tokenAccount))
            query.Add($"token_account={_tokenAccount}");

        if (!string.IsNullOrEmpty(_from))
            query.Add($"from={_from}");

        if (!string.IsNullOrEmpty(_to))
            query.Add($"to={_to}");

        if (!string.IsNullOrEmpty(_token))
            query.Add($"token={_token}");

        foreach (var amount in _amounts)
            query.Add($"amount[]={amount}");

        foreach (var blockTime in _blockTimes)
            query.Add($"block_time[]={blockTime}");

        foreach (var time in _times)
            query.Add($"time[]={time}");

        if (_excludeAmountZero != null)
            query.Add($"exclude_amount_zero={_excludeAmountZero.Value.ToString().ToLowerInvariant()}");

        if (_removeSpam != null)
            query.Add($"remove_spam={_removeSpam.Value.ToString().ToLowerInvariant()}");

        if (!string.IsNullOrEmpty(_flow))
            query.Add($"flow={_flow}");

        if (_page > 0)
            query.Add($"page={_page}");

        if (_pageSize > 0)
            query.Add($"page_size={_pageSize}");

        if (_timeFrom > 0)
            query.Add($"time_from={_timeFrom}");

        if (_timeTo > 0)
            query.Add($"time_to={_timeTo}");

        if (_blockNumber > 0)
            query.Add($"block={_blockNumber}");

        if (!string.IsNullOrEmpty(_sortBy))
            query.Add($"sort_by={_sortBy}");

        if (!string.IsNullOrEmpty(_sortOrder))
            query.Add($"sort_order={_sortOrder}");

        if (!string.IsNullOrEmpty(_tokenType))
            query.Add($"type={_tokenType}");

        if (!string.IsNullOrEmpty(_filter))
            query.Add($"filter={_filter}");

        if (_hideZero != null)
        {
            query.Add($"hide_zero={_hideZero.Value.ToString().ToLowerInvariant()}");
        }

        return $"{_baseUrl}?{string.Join("&", query)}";
    }
}