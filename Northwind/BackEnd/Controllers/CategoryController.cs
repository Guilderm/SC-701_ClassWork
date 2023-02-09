using BackEnd.Models;
using DAL.Interfaces;
using DAL.Repositories;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
	{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IGenericRepository<Category> _Repository;

	public CategoryController()
		{
		_unitOfWork = new UnitOfWork();
		_Repository = _unitOfWork.GetRepository<Category>();
		}

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

	#region GET: api/<CategoryController>
	[HttpGet]
	public JsonResult Get()
		{
		IEnumerable<Category> categories = _Repository.GetAll();

		var categoryList = new List<CategoryModel>();

		foreach (Category category in categories)
			{
			categoryList.Add(MapEntityToModel(category)

				 );
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

	#region POST api/<CategoryController>
	[HttpPost]
	public JsonResult Post([FromBody] CategoryModel category)
		{
		Category entity = MapModelToEntity(category);

		_Repository.Add(entity);
		_unitOfWork.SaveChanges();

		return new JsonResult(MapEntityToModel(entity));
		}
	#endregion

	#region PUT api/<CategoryController>/5
	[HttpPut]
	public JsonResult Put([FromBody] CategoryModel category)
		{
		_Repository.Update(MapModelToEntity(category));
		_unitOfWork.SaveChanges();

		return new JsonResult(MapModelToEntity(category));
		}
	#endregion

	#region  DELETE api/<CategoryController>/5
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