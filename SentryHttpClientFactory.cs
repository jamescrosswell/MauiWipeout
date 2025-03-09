namespace MauiWipeout;

internal class SentryHttpClientFactory : IHttpClientFactory
{
	public HttpClient CreateClient(string name) => new HttpClient(new SentryHttpMessageHandler());
}
