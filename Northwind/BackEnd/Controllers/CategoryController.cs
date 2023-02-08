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
		_unitOfWork = new UnitOfWork(new DBContext());
		}

	#region HttpGet
	[HttpGet]
	public JsonResult Get()
		{
		IEnumerable<Category> categories = _unitOfWork.Category.GetAll();
		return new JsonResult(categories);
		}

	[HttpGet("{id}")]
	public JsonResult Get(int id)
		{
		Category category;
		category = _unitOfWork.Category.Get(id);

		return new JsonResult(category);
		}
	#endregion

	#region HttpPost
	[HttpPost]
	public JsonResult Post([FromBody] Category category)
		{
		_ = _unitOfWork.Category.Add(category);

		return new JsonResult(category);
		}
	#endregion

	#region HttpPut
	[HttpPut]
	public JsonResult Put([FromBody] Category category)
		{
		_ = _unitOfWork.Category.Update(category);

		return new JsonResult(category);
		}
	#endregion

	#region HttpDelete
	[HttpDelete("{id}")]
	public JsonResult Delete(int id)
		{
		Category category = new() { CategoryId=id };
		_ = _unitOfWork.Category.Remove(category);

		return new JsonResult(category);
		}
	#endregion
	}