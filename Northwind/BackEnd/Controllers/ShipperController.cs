using AutoMapper;
using BackEnd.DTOs;
using DAL.Interfaces;
using Entities;

namespace BackEnd.Controllers;

public class ShipperController : BaseApiController<Shipper, ShipperDto>
	{

	private readonly ILogger<ShipperController> _logger;
	public ShipperController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ShipperController> logger) : base(unitOfWork, mapper)
		{
		_logger = logger;
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