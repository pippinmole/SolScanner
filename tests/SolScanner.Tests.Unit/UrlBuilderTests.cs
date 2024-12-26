using SolScanner;

namespace Solscanner.Tests.Unit;

[TestFixture]
internal sealed class UrlBuilderTests
{
    [Test]
    public void Build_ValidBaseUrl_ReturnsCorrectUrl()
    {
        // Arrange
        var builder = new UrlBuilder()
            .WithBaseUrl("https://example.com")
            .WithAddress("testAddress")
            .WithActivityTypes(EActivityType.ACTIVITY_SPL_BURN, EActivityType.ACTIVITY_SPL_BURN)
            .WithAmounts(1, 2, 3)
            .WithPage(1)
            .WithPageSize(10)
            .WithSortBy("block_time")
            .WithSortOrder("asc");

        // Act
        var result = builder.Build();

        // Assert
        Assert.That(result, Contains.Substring("https://example.com"));
        Assert.That(result, Contains.Substring("address=testAddress"));
        Assert.That(result, Contains.Substring("activity_type[]=ACTIVITY_SPL_BURN"));
        Assert.That(result, Contains.Substring("activity_type[]=ACTIVITY_SPL_BURN"));
        Assert.That(result, Contains.Substring("amount[]=1"));
        Assert.That(result, Contains.Substring("page=1"));
    }

    [Test]
    public void Build_MissingBaseUrl_ThrowsException()
    {
        var builder = new UrlBuilder()
            .WithAddress("testAddress");

        Assert.Throws<InvalidOperationException>(() => builder.Build());
    }

    [Test]
    public void WithActivityTypes_AddsMultipleActivityTypesToUrl()
    {
        var builder = new UrlBuilder()
            .WithBaseUrl("https://example.com")
            .WithActivityTypes(EActivityType.ACTIVITY_SPL_TRANSFER, EActivityType.ACTIVITY_SPL_BURN, EActivityType.ACTIVITY_SPL_MINT, EActivityType.ACTIVITY_SPL_CREATE_ACCOUNT);
    
        var result = builder.Build();
    
        Assert.That(result, Contains.Substring("activity_type[]=ACTIVITY_SPL_TRANSFER"));
        Assert.That(result, Contains.Substring("activity_type[]=ACTIVITY_SPL_BURN"));
        Assert.That(result, Contains.Substring("activity_type[]=ACTIVITY_SPL_MINT"));
        Assert.That(result, Contains.Substring("activity_type[]=ACTIVITY_SPL_CREATE_ACCOUNT"));
    }

    [Test]
    public void WithAmounts_AddsMultipleAmountsToUrl()
    {
        var builder = new UrlBuilder()
            .WithBaseUrl("https://example.com")
            .WithAmounts(10, 20, 30);

        var result = builder.Build();

        Assert.That(result, Contains.Substring("amount[]=10"));
        Assert.That(result, Contains.Substring("amount[]=20"));
        Assert.That(result, Contains.Substring("amount[]=30"));
    }

    [Test]
    public void ExcludeAmountZero_SetTrue_AddsExcludeParameter()
    {
        var builder = new UrlBuilder()
            .WithBaseUrl("https://example.com")
            .ExcludeAmountZero(true);

        var result = builder.Build();

        Assert.That(result, Contains.Substring("exclude_amount_zero=true"));
    }

    [Test]
    public void WithPageAndPageSize_AddsCorrectPaginationToUrl()
    {
        var builder = new UrlBuilder()
            .WithBaseUrl("https://example.com")
            .WithPage(2)
            .WithPageSize(50);

        var result = builder.Build();

        Assert.That(result, Contains.Substring("page=2"));
        Assert.That(result, Contains.Substring("page_size=50"));
    }
}
