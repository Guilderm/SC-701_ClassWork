﻿using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers;

public class CategoryHelper
	{
	private readonly ServiceRepository ServiceRepository;

	public CategoryHelper()
		{
		ServiceRepository = new ServiceRepository();
		}

	public List<CategoryViewModel> GetAll()
		{
		List<CategoryViewModel> lista;

		HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/category/");
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		lista = JsonConvert.DeserializeObject<List<CategoryViewModel>>(content);

		return lista;
		}

	public CategoryViewModel Get(int id)
		{
		CategoryViewModel Category;

		HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/category/" + id.ToString());
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		Category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

		return Category;
		}

	public CategoryViewModel Create(CategoryViewModel category)
		{

		CategoryViewModel Category;

		HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/category/" ,category);
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		Category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

		return Category;
		}

	public CategoryViewModel Edit(CategoryViewModel category)
		{

		CategoryViewModel Category;

		HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/category/", category);
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		Category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

		return Category;
		}

	public CategoryViewModel Delete(int id)
		{

		CategoryViewModel Category;

		HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/category/" + id.ToString());
		string content = responseMessage.Content.ReadAsStringAsync().Result;
		Category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

		return Category;
		}
	}