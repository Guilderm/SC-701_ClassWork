using AutoMapper;
using BackEnd.DTOs;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

public class ShipperController : BaseApiController<Shipper, ShipperDto>
{
	private readonly ILogger<ShipperController> _logger;

	public ShipperController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ShipperController> logger) : base(
		unitOfWork, mapper)
	{
		_logger = logger;
	}

	#region POST|Create - Used to create a new resource.

	[HttpPost]
	public override IActionResult Post([FromBody] ShipperDto requestDto)
	{
		_logger.LogInformation($"will look for Entity with of name {nameof(requestDto)} and see if we get it.");

		if (!ModelState.IsValid)
		{
			_logger.LogError($"Invalid POST attempt in {nameof(requestDto)}");
			return BadRequest(ModelState);
		}

		Shipper mappedResult = Mapper.Map<Shipper>(requestDto);

		Repository.Insert(mappedResult);
		UnitOfWork.SaveChanges();

		_logger.LogCritical($"The ID of Entity with of name {nameof(requestDto)} is {mappedResult.ShipperId} .");

		return CreatedAtAction(nameof(Get), new { id = mappedResult.ShipperId }, mappedResult);
	}

	#endregion
}