using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Services;

public class CategoryService
{
	private readonly HttpService _httpService;
	private readonly string _resourcePath;


	public CategoryService(IConfiguration configuration)
	{
		_httpService = new HttpService(configuration);
		_resourcePath = configuration.GetSection("BackendURLs")["categoryPath"];
	}

	public List<CategoryViewModel> GetAll()
	{
		HttpResponseMessage responseMessage = _httpService.GetResponse(_resourcePath);
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		return JsonConvert.DeserializeObject<List<CategoryViewModel>>(content);
	}

	public CategoryViewModel Get(int id)
	{
		HttpResponseMessage responseMessage = _httpService.GetResponse(_resourcePath + id);
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		CategoryViewModel category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

		return category;
	}

	public CategoryViewModel Create(CategoryViewModel category)
	{
		HttpResponseMessage responseMessage = _httpService.PostResponse(_resourcePath, category);
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

		return category;
	}


	public CategoryViewModel Edit(CategoryViewModel category)
	{
		HttpResponseMessage responseMessage = _httpService.PutResponse(_resourcePath, category);
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

		return category;
	}

	public CategoryViewModel Delete(int id)
	{
		CategoryViewModel category;

		HttpResponseMessage responseMessage = _httpService.DeleteResponse(_resourcePath + id);
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

		return category;
	}
}