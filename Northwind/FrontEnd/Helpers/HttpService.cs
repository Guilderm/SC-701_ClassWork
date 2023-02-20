namespace FrontEnd.Helpers;

public class HttpService
{
	public HttpService()
	{
		Client = new HttpClient
		{
			BaseAddress = new Uri("http://localhost:5283")
		};
	}

	private HttpClient Client { get; }

	public HttpResponseMessage GetResponse(string url)
	{
		return Client.GetAsync(url).Result;
	}

	public HttpResponseMessage PutResponse(string url, object model)
	{
		return Client.PutAsJsonAsync(url, model).Result;
	}

	public HttpResponseMessage PostResponse(string url, object model)
	{
		return Client.PostAsJsonAsync(url, model).Result;
	}

	public HttpResponseMessage DeleteResponse(string url)
	{
		return Client.DeleteAsync(url).Result;
	}
}