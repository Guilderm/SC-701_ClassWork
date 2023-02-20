﻿namespace FrontEnd.Helpers;

public class HttpService
{
	public HttpService(IConfiguration configuration)
	{
		string baseUrl = configuration.GetSection("BackendURLs")["baseUrl"];
		Client = new HttpClient();
		Client.BaseAddress = new Uri(baseUrl);
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