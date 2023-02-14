using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseAPIController<TEntity, TModel> : ControllerBase
	 where TEntity : class, new()
	 where TModel : class, new()
	{
	protected readonly IUnitOfWork _unitOfWork;
	protected readonly IGenericRepository<TEntity> _Repository;
	protected readonly IMapper _Mapper;
	private readonly ILogger<BaseAPIController<TEntity, TModel>> _logger;

	public BaseAPIController(IUnitOfWork unitOfWork, IMapper Mapper)
		{
		_unitOfWork = unitOfWork;
		_Repository = _unitOfWork.GetRepository<TEntity>();
		_Mapper = Mapper;
		_logger = new LoggerFactory().CreateLogger<BaseAPIController<TEntity, TModel>>()
		;
		}

	#region POST|Create - Used to create a new resource.
	[HttpPost]
	public virtual IActionResult Post([FromBody] TModel requestDTO)
		{
		if (!ModelState.IsValid)
			{
			return BadRequest(ModelState);
			}

		TEntity mappedResult = _Mapper.Map<TEntity>(requestDTO);

		_Repository.Insert(mappedResult);
		_unitOfWork.SaveChanges();

		//return CreatedAtAction(nameof(Get), new { id = mappedResult.Id }, mappedResult);
		return Ok(mappedResult);
		}
	#endregion

	#region GET|Read - Used to retrieve a resource or a collection of resources.
	[HttpGet]
	public IActionResult Get()
		{
		if (!ModelState.IsValid)
			{
			return BadRequest(ModelState);
			}
		IEnumerable<TEntity> dbResult = _Repository.GetAll();
		IList<TModel> mappedResult = _Mapper.Map<IList<TModel>>(dbResult);
		return Ok(mappedResult);
		}

	[HttpGet("{id}")]
	public IActionResult Get(int id)
		{
		if (!ModelState.IsValid)
			{
			return BadRequest(ModelState);
			}
		TEntity dbResult = _Repository.Get(id);
		TModel mappedResult = _Mapper.Map<TModel>(dbResult);
		return Ok(mappedResult);
		}
	#endregion

	#region PUT|Update - Used to update an existing resource.
	[HttpPut]
	public IActionResult Put([FromBody] TModel requestDTO)
		{
		if (!ModelState.IsValid)
			{
			return BadRequest(ModelState);
			}
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
		if (!ModelState.IsValid)
			{
			return BadRequest(ModelState);
			}
		TEntity dbResult = _Repository.Get(id);
		_Repository.Remove(dbResult);
		_unitOfWork.SaveChanges();

		return NoContent();
		}
	#endregion
	}