namespace FrontEnd.Helpers;


public class ServiceRepository
	{
	public HttpClient Client { get; set; }

	public ServiceRepository()
		{
		Client = new HttpClient
			{
			BaseAddress = new Uri("http://localhost:5283")
			};

		}
	public HttpResponseMessage GetResponse(string url) => Client.GetAsync(url).Result;
	public HttpResponseMessage PutResponse(string url, object model) => Client.PutAsJsonAsync(url, model).Result;
	public HttpResponseMessage PostResponse(string url, object model) => Client.PostAsJsonAsync(url, model).Result;
	public HttpResponseMessage DeleteResponse(string url) => Client.DeleteAsync(url).Result;



	}

