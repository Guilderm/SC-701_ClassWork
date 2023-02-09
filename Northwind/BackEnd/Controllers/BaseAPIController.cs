using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController<TEntity, TModel> : ControllerBase
	where TEntity : class
	where TModel : class
	{
	protected readonly IUnitOfWork _unitOfWork;
	protected readonly IGenericRepository<TEntity> _Repository;
	protected readonly IMapper _Mapper;

	public BaseController(IUnitOfWork unitOfWork, IMapper Mapper)
		{
		_unitOfWork = unitOfWork;
		_Repository = _unitOfWork.GetRepository<TEntity>();
		_Mapper = Mapper;
		}

	#region GET|Read - Used to retrieve a resource or a collection of resources.
	[HttpGet]
	public IActionResult Get()
		{
		IEnumerable<TEntity> dbResult = _Repository.GetAll();
		IList<TModel> mappedResult = _Mapper.Map<IList<TModel>>(dbResult);
		return Ok(mappedResult);
		}

	[HttpGet("{id}")]
	public IActionResult Get(int id)
		{
		TEntity dbResult = _Repository.Get(id);
		TModel mappedResult = _Mapper.Map<TModel>(dbResult);
		return Ok(mappedResult);
		}
	#endregion

	#region POST|Create - Used to create a new resource.
	[HttpPost]
	public IActionResult Post([FromBody] TModel requestDTO)
		{
		TEntity mappedResult = _Mapper.Map<TEntity>(requestDTO);

		_Repository.Add(mappedResult);
		_unitOfWork.SaveChanges();

		//TEntity dbResult = _Repository.Get(mappedResult.CategoryId);

		return Ok(mappedResult);
		}
	#endregion

	#region PUT|Update - Used to update an existing resource.
	[HttpPut]
	public IActionResult Put([FromBody] TModel requestDTO)
		{
		TEntity mappedResult = _Mapper.Map<TEntity>(requestDTO);
		_Repository.Update(mappedResult);
		_unitOfWork.SaveChanges();

		return Ok(mappedResult);
		}
	#endregion

	#region  PATCH|Update - Used to partially update an existing resource.
	[HttpPatch]
	public IActionResult Patch() => throw new NotImplementedException();
	#endregion

	#region  DELETE|Delete - Used to delete a resource.
	[HttpDelete("{id:int}")]
	public IActionResult Delete(int id)
		{
		TEntity dbResult = _Repository.Get(id);
		_Repository.Remove(dbResult);
		_unitOfWork.SaveChanges();

		return NoContent();
		}
	#endregion
	}