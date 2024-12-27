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