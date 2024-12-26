using SolScanner;

namespace Solscanner.Tests.Unit;

public class Tests
{
    private SolscanClient _client = null!;
    
    [SetUp]
    public void Setup()
    {
        _client = new SolscanClient("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjcmVhdGVkQXQiOjE3MzQ5ODM4NTA0NDEsImVtYWlsIjoic29sc2Nhbl85aW54b25AZW1hbGlhcy5hcHAiLCJhY3Rpb24iOiJ0b2tlbi1hcGkiLCJhcGlWZXJzaW9uIjoidjIiLCJpYXQiOjE3MzQ5ODM4NTB9.Gktw1EgpIJO0Ba0FNDKI2YZyjrZ_cMzn3G4Mf2ZgzM8");
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