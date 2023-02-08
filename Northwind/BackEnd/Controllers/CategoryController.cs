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

	public CategoryController()
		{
		_unitOfWork = new UnitOfWork();
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

	#region Consultar
	// GET: api/<CategoryController>
	[HttpGet]
	public JsonResult Get()
		{
		IEnumerable<Category> categories = _unitOfWork.Category.GetAll();

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

	#region Agregar
	// POST api/<CategoryController>
	[HttpPost]
	public JsonResult Post([FromBody] CategoryModel category)
		{
		Category entity = MapModelToEntity(category);
		_ = _unitOfWork.Category.Add(entity);
		return new JsonResult(MapEntityToModel(entity));
		}

	#endregion

	#region MOdificar
	// PUT api/<CategoryController>/5
	[HttpPut]
	public JsonResult Put([FromBody] CategoryModel category)
		{

		_ = _unitOfWork.Category.Update(MapModelToEntity(category));
		return new JsonResult(MapModelToEntity(category));
		}
	#endregion

	#region Eliminar
	// DELETE api/<CategoryController>/5
	[HttpDelete("{id}")]
	public JsonResult Delete(int id)
		{
		var category = new Category { CategoryId= id };
		_ = _unitOfWork.Category.Remove(category);

		return new JsonResult(MapEntityToModel(category));
		}
	#endregion
	}