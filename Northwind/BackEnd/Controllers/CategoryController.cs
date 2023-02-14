using AutoMapper;
using BackEnd.DTOs;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

public class CategoryController : BaseAPIController<Category, CategoryDTO>
	{
	private readonly ILogger<CategoryController> _logger;

	public CategoryController(IUnitOfWork unitOfWork, IMapper Mapper, ILogger<CategoryController> logger) : base(unitOfWork, Mapper)
		{
		_logger = logger;
		}

	#region POST|Create - Used to create a new resource.
	[HttpPost]
	public override IActionResult Post([FromBody] CategoryDTO requestDTO)
		{
		_logger.LogCritical($"will look for Entity with of name {nameof(requestDTO)} and see if we get it.");
		if (!ModelState.IsValid)
			{
			_logger.LogError($"Invalid POST attempt in {nameof(requestDTO)}");
			return BadRequest(ModelState);
			}

		Category mappedResult = _Mapper.Map<Category>(requestDTO);

		_Repository.Insert(mappedResult);
		_unitOfWork.SaveChanges();
		_logger.LogCritical($"The ID of Entity with of name {nameof(requestDTO)} is {mappedResult.CategoryId} .");
		//TEntity dbResult = _Repository.Get(mappedResult.CategoryId);

		return CreatedAtAction(nameof(Get), new { id = mappedResult.CategoryId }, mappedResult);
		}
	#endregion

	}