using AutoMapper;
using BackEnd.DTOs;
using DAL.Interfaces;
using Entities;

namespace BackEnd.Controllers;

public class ShipperController : BaseAPIController<Shipper, ShipperDTO>
	{
	public ShipperController(IUnitOfWork unitOfWork, IMapper Mapper) : base(unitOfWork, Mapper)
		{
		}

	/*
	#region POST|Create - Used to create a new resource.
	[HttpPost]
	public override IActionResult Post([FromBody] ShipperDTO requestDTO)
		{

		if (!ModelState.IsValid)
			{
			//_logger.LogError($"Invalid POST attempt in {nameof(CreateCountry)}");
			return BadRequest(ModelState);
			}

		Shipper mappedResult = _Mapper.Map<Shipper>(requestDTO);

		_Repository.Insert(mappedResult);
		_unitOfWork.SaveChanges();

		//TEntity dbResult = _Repository.Get(mappedResult.CategoryId);

		return CreatedAtAction(nameof(Get), new { id = mappedResult.ShipperId }, mappedResult);
		}
	#endregion
	*/
	}