namespace FrontEnd.Helpers;

public class HttpService
{
	private readonly HttpClient _client;

	public HttpService(IConfiguration configuration)
	{
		string? baseUrl = configuration.GetValue<string>("baseUrl");
		if (string.IsNullOrEmpty(baseUrl))
		{
			throw new ArgumentException("Base URL not found in configuration.");
		}

		_client.BaseAddress = new Uri(baseUrl);
	}

	public HttpResponseMessage GetResponse(string url)
	{
		return _client.GetAsync(url).Result;
	}

	public HttpResponseMessage PutResponse(string url, object model)
	{
		return _client.PutAsJsonAsync(url, model).Result;
	}

	public HttpResponseMessage PostResponse(string url, object model)
	{
		return _client.PostAsJsonAsync(url, model).Result;
	}

	public HttpResponseMessage DeleteResponse(string url)
	{
		return _client.DeleteAsync(url).Result;
	}
}