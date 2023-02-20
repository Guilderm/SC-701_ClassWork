using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers;

public class CategoryHelper
{
	private readonly HttpService _httpService;


	public CategoryHelper()
	{
		_httpService = new HttpService();
	}

	public List<CategoryViewModel> GetAll()
	{
		List<CategoryViewModel> lista;

		HttpResponseMessage responseMessage = _httpService.GetResponse("api/category/");
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		lista = JsonConvert.DeserializeObject<List<CategoryViewModel>>(content);


		return lista;
	}

	public CategoryViewModel Get(int id)
	{
		CategoryViewModel category;

		HttpResponseMessage responseMessage = _httpService.GetResponse("api/category/" + id);
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

		return category;
	}

	public CategoryViewModel Create(CategoryViewModel category)
	{
		HttpResponseMessage responseMessage = _httpService.PostResponse("api/category/", category);
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

		return category;
	}


	public CategoryViewModel Edit(CategoryViewModel category)
	{
		HttpResponseMessage responseMessage = _httpService.PutResponse("api/category/", category);
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

		return category;
	}

	public CategoryViewModel Delete(int id)
	{
		CategoryViewModel category;

		HttpResponseMessage responseMessage = _httpService.DeleteResponse("api/category/" + id);
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

		return category;
	}
}