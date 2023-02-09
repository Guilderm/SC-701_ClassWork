using BackEnd.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

public class CategoryController : BaseController<Category>
	{
	#region Mappers
	private static CategoryModel MapEntityToModel(Category entity)
		{
		return new CategoryModel
			{
			CategoryId = entity.CategoryId,
			CategoryName = entity.CategoryName,
			Description = entity.Description
			};
		}

	private static Category MapModelToEntity(CategoryModel model)
		{
		return new Category
			{
			CategoryId = model.CategoryId,
			CategoryName = model.CategoryName,
			Description = model.Description
			};
		}
	#endregion

	#region GET|Read - Used to retrieve a resource or a collection of resources.
	[HttpGet]
	public JsonResult Get()
		{
		IEnumerable<Category> categories = _Repository.GetAll();

		var categoryList = new List<CategoryModel>();

		foreach (Category category in categories)
			{
			categoryList.Add(MapEntityToModel(category));
			}

		return new JsonResult(categoryList);
		}

	// GET api/<CategoryController>/5
	[HttpGet("{id}")]
	public JsonResult Get(int id)
		{
		Category category;
		category = _unitOfWork.Category.Get(id);

		return new JsonResult(MapEntityToModel(category));

		}
	#endregion

	#region POST|Create - Used to create a new resource.
	[HttpPost]
	public JsonResult Post([FromBody] CategoryModel category)
		{
		Category entity = MapModelToEntity(category);

		_Repository.Add(entity);
		_unitOfWork.SaveChanges();

		return new JsonResult(MapEntityToModel(entity));
		}
	#endregion

	#region PUT|Update - Used to update an existing resource.
	[HttpPut]
	public JsonResult Put([FromBody] CategoryModel category)
		{
		_Repository.Update(MapModelToEntity(category));
		_unitOfWork.SaveChanges();

		return new JsonResult(MapModelToEntity(category));
		}
	#endregion

	#region  PATCH|Update - Used to partially update an existing resource.
	//Not implemented
	#endregion

	#region  DELETE|Delete - Used to delete a resource.
	[HttpDelete("{id}")]
	public JsonResult Delete(int id)
		{
		var category = new Category { CategoryId= id };
		_Repository.Remove(category);
		_unitOfWork.SaveChanges();

		return new JsonResult(MapEntityToModel(category));
		}
	#endregion
	}