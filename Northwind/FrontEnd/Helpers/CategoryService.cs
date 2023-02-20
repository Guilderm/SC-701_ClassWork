using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers;

public class CategoryService
{
	private readonly HttpService _httpService;
	private readonly string _resourcePath;


	public CategoryService(IConfiguration configuration)
	{
		_httpService = new HttpService();
		_resourcePath = configuration.GetSection("BackendURLs")["categoryPath"];
	}

	public List<CategoryViewModel> GetAll()
	{
		List<CategoryViewModel> lista;

		HttpResponseMessage responseMessage = _httpService.GetResponse(_resourcePath);
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		lista = JsonConvert.DeserializeObject<List<CategoryViewModel>>(content);


		return lista;
	}

	public CategoryViewModel Get(int id)
	{
		CategoryViewModel category;

		HttpResponseMessage responseMessage = _httpService.GetResponse(_resourcePath + id);
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

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