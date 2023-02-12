using AutoMapper;
using BackEnd.DTOs;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

public class CategoryController : BaseAPIController<Category, CategoryDTO>
	{
	public CategoryController(IUnitOfWork unitOfWork, IMapper Mapper) : base(unitOfWork, Mapper)
		{
		}

	#region POST|Create - Used to create a new resource.
	[HttpPost]
	public override IActionResult Post([FromBody] CategoryDTO requestDTO)
		{

		if (!ModelState.IsValid)
			{
			//_logger.LogError($"Invalid POST attempt in {nameof(CreateCountry)}");
			return BadRequest(ModelState);
			}

		Category mappedResult = _Mapper.Map<Category>(requestDTO);

		_Repository.Insert(mappedResult);
		_unitOfWork.SaveChanges();

		//TEntity dbResult = _Repository.Get(mappedResult.CategoryId);

		return CreatedAtAction(nameof(Get), new { id = mappedResult.CategoryId }, mappedResult);
		}
	#endregion

	}