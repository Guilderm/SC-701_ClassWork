using DAL.Interfaces;
using DAL.Repositories;

using Entities;

using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShipperController : ControllerBase
{
    private readonly IShipperRepository _ShipperRepository;

    public ShipperController()
    {
        _ShipperRepository = new ShipperRepository(new DBContext());
    }

    #region HttpGet
    [HttpGet]
    public JsonResult Get()
    {
        IEnumerable<Shipper> categories = _ShipperRepository.GetAll();

        return new JsonResult(categories);
    }

    [HttpGet("{id}")]
    public JsonResult Get(int id)
    {
        Shipper Shipper;
        Shipper = _ShipperRepository.Get(id);

        return new JsonResult(Shipper);
    }
    #endregion

    #region HttpPost
    [HttpPost]
    public JsonResult Post([FromBody] Shipper Shipper)
    {
        _ = _ShipperRepository.Add(Shipper);

        return new JsonResult(Shipper);
    }
    #endregion

    #region HttpPut
    [HttpPut]
    public JsonResult Put([FromBody] Shipper Shipper)
    {
        _ = _ShipperRepository.Update(Shipper);

        return new JsonResult(Shipper);
    }
    #endregion

    #region HttpDelete
    [HttpDelete("{id}")]
    public JsonResult Delete(int id)
    {
        Shipper Shipper = new() { ShipperId = id };
        _ = _ShipperRepository.Remove(Shipper);

        return new JsonResult(Shipper);
    }
    #endregion
}