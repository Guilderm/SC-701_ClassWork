namespace FrontEnd.Services;

public class HttpService
{
	private readonly HttpClient _client = new();

	public HttpService(IConfiguration configuration)
	{
		_client.BaseAddress = new Uri(configuration.GetSection("BackendURLs")["baseUrl"]);
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