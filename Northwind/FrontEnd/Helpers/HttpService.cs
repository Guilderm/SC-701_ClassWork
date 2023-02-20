namespace FrontEnd.Helpers;

public class ServiceRepository
{
	public ServiceRepository()
	{
		Client = new HttpClient
		{
			BaseAddress = new Uri("http://localhost:5283")
		};
	}

	public HttpClient Client { get; set; }

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