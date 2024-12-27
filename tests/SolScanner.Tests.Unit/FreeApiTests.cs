using Microsoft.Extensions.Configuration;
using SolScanner;

namespace Solscanner.Tests.Unit;

public class Tests
{
    private SolscanClient _client = null!;
    
    [SetUp]
    public void Setup()
    {
        var config = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var apiKey = config["SolScan:ApiKey"];
        _client = new SolscanClient(apiKey, new HttpClient());
    }

    [Test]
    public async Task GetChainInformation_ReturnsData()
    {
        // Arrange
        
        // Act
        var result = await _client.GetChainInformation();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.Data, Is.Not.Null);
            
            Assert.That(result.Data.BlockHeight, Is.Not.Zero);
            Assert.That(result.Data.CurrentEpoch, Is.Not.Zero);
            Assert.That(result.Data.AbsoluteSlot, Is.Not.Zero);
            Assert.That(result.Data.TransactionCount, Is.Not.Zero);
        });
    }
}