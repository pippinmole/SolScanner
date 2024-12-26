using System;
using System.Collections.Generic;
using System.Linq;

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
    private bool _excludeAmountZero;
    private string _flow;
    private uint _page;
    private uint _pageSize;
    private string _sortBy;
    private string _sortOrder;
    private string _tokenType;
    private bool? _hideZero = null;

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

    public UrlBuilder WithFlow(string flow)
    {
        _flow = flow;
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

    public string Build()
    {
        if (string.IsNullOrEmpty(_baseUrl))
            throw new InvalidOperationException("Base URL must be set.");

        var query = new List<string>();

        if (!string.IsNullOrEmpty(_address))
            query.Add($"address={_address}");

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

        if (_excludeAmountZero)
            query.Add("exclude_amount_zero=true");

        if (!string.IsNullOrEmpty(_flow))
            query.Add($"flow={_flow}");

        if (_page > 0)
            query.Add($"page={_page}");

        if (_pageSize > 0)
            query.Add($"page_size={_pageSize}");

        if (!string.IsNullOrEmpty(_sortBy))
            query.Add($"sort_by={_sortBy}");

        if (!string.IsNullOrEmpty(_sortOrder))
            query.Add($"sort_order={_sortOrder}");
        
        if (!string.IsNullOrEmpty(_tokenType))
            query.Add($"type={_tokenType}");

        if (_hideZero != null)
        {
            query.Add($"hide_zero=${_hideZero}");
        }

        return $"{_baseUrl}?{string.Join("&", query)}";
    }
}