using DAL.Interfaces;
using DAL.Repositories;

using Entities;

using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShipperController : ControllerBase
{
    private readonly IShipperRepository _ShipperDAL;

    public ShipperController()
    {
        _ShipperDAL = new ShipperRepository(new DBContext());
    }

    #region HttpGet
    [HttpGet]
    public JsonResult Get()
    {
        IEnumerable<Shipper> categories = _ShipperDAL.GetAll();

        return new JsonResult(categories);
    }

    [HttpGet("{id}")]
    public JsonResult Get(int id)
    {
        Shipper Shipper;
        Shipper = _ShipperDAL.Get(id);

        return new JsonResult(Shipper);
    }
    #endregion

    #region HttpPost
    [HttpPost]
    public JsonResult Post([FromBody] Shipper Shipper)
    {
        _ = _ShipperDAL.Add(Shipper);

        return new JsonResult(Shipper);
    }
    #endregion

    #region HttpPut
    [HttpPut]
    public JsonResult Put([FromBody] Shipper Shipper)
    {
        _ = _ShipperDAL.Update(Shipper);

        return new JsonResult(Shipper);
    }
    #endregion

    #region HttpDelete
    [HttpDelete("{id}")]
    public JsonResult Delete(int id)
    {
        Shipper Shipper = new() { ShipperId = id };
        _ = _ShipperDAL.Remove(Shipper);

        return new JsonResult(Shipper);
    }
    #endregion
}