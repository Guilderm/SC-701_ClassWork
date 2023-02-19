using AutoMapper;
using BackEnd.DTOs;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

public class CategoryController : BaseApiController<Category, CategoryDto>
	{
	private readonly ILogger<CategoryController> _logger;

	public CategoryController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CategoryController> logger) : base(
		unitOfWork, mapper)
		{
		_logger = logger;
		}

	//refactor so to extract IActionResult Post([FromBody] CategoryDto requestDto) to BaseApiController

	#region POST|Create - Used to create a new resource.

	[HttpPost]
	public override IActionResult Post([FromBody] CategoryDto requestDto)
		{
		_logger.LogCritical($"will look for Entity with of name {nameof(requestDto)} and see if we get it.");

		if (!ModelState.IsValid)
			{
			_logger.LogError($"Invalid POST attempt in {nameof(requestDto)}");
			return BadRequest(ModelState);
			}

		Category mappedResult = Mapper.Map<Category>(requestDto);

		Repository.Insert(mappedResult);
		UnitOfWork.SaveChanges();

		_logger.LogCritical($"The ID of Entity with of name {nameof(requestDto)} is {mappedResult.CategoryId} .");
		//TEntity dbResult = _Repository.Get(mappedResult.CategoryId);

		return CreatedAtAction(nameof(Get), new { id = mappedResult.CategoryId }, mappedResult);
		}

	#endregion
	}