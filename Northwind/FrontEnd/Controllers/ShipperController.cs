using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers;

public class ShipperController : Controller
{
    private readonly ILogger<ShipperController> _logger;
    private readonly ShippersService _shippersService;

    public ShipperController(ShippersService shippersService, ILogger<ShipperController> logger)
    {
        _shippersService = shippersService;
        _logger = logger;
    }

    // GET: ShipperController
    public ActionResult Index()
    {
        return View(_shippersService.GetAll());
    }

    // GET: ShipperController/Details/5
    public ActionResult Details(int id)
    {
        return View(_shippersService.Get(id));
    }

    // GET: ShipperController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ShipperController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ShippersViewModel Shipper)
    {
        try
        {
            return RedirectToAction("Details", new { id = _shippersService.Create(Shipper).ShipperId });
        }
        catch
        {
            return View();
        }
    }

    // GET: ShipperController/Edit/5
    public ActionResult Edit(int id)
    {
        return View(_shippersService.Get(id));
    }

    // POST: ShipperController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(ShippersViewModel Shipper)
    {
        try
        {
            _shippersService.Edit(Shipper);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ShipperController/Delete/5
    public ActionResult Delete(int id)
    {
        return View(_shippersService.Get(id));
    }

    // POST: ShipperController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, ShippersViewModel Shipper)
    {
        try
        {
            _shippersService.Delete(Shipper.ShipperId);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}