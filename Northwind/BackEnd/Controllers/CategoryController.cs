using AutoMapper;
using BackEnd.DTOs;
using DAL.Interfaces;
using Entities;

namespace BackEnd.Controllers;

public class CategoryController : BaseController<Category, CategoryDTO>
	{
	public CategoryController(IUnitOfWork unitOfWork, IMapper Mapper) : base(unitOfWork, Mapper)
		{
		}
	/*
	#region GET|Read - Used to retrieve a resource or a collection of resources.
	[HttpGet]
	public IActionResult Get()
		{
		IEnumerable<Category> dbResult = _Repository.GetAll();
		IList<CategoryDTO> mappedResult = _Mapper.Map<IList<CategoryDTO>>(dbResult);
		return Ok(mappedResult);
		}

	[HttpGet("{id:int}")]
	public IActionResult Get(int id)
		{
		Category dbResult = _Repository.Get(id);
		CategoryDTO mappedResult = _Mapper.Map<CategoryDTO>(dbResult);
		return Ok(mappedResult);
		}
	#endregion

	#region POST|Create - Used to create a new resource.
	[HttpPost]
	public IActionResult Post([FromBody] CategoryDTO requestDTO)
		{
		Category mappedResult = _Mapper.Map<Category>(requestDTO);

		_Repository.Add(mappedResult);
		_unitOfWork.SaveChanges();

		Category dbResult = _Repository.Get(mappedResult.CategoryId);

		return Ok(dbResult);
		}
	#endregion

	#region PUT|Update - Used to update an existing resource.
	[HttpPut]
	public IActionResult Put([FromBody] CategoryDTO requestDTO)
		{
		Category result = _Mapper.Map<Category>(requestDTO);
		_Repository.Update(result);
		_unitOfWork.SaveChanges();

		return Ok(result);
		}
	#endregion

	#region DELETE|Delete - Used to delete a resource.
	[HttpDelete("{id:int}")]
	public IActionResult Delete(int id)
		{
		Category dbResult = _Repository.Get(id);
		_Repository.Remove(dbResult);
		_unitOfWork.SaveChanges();

		return NoContent();
		}
	#endregion
	*/
	}