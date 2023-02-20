using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers;

public class CategoryController : Controller
{
	private readonly CategoryService _categoryService;

	public CategoryController(IConfiguration configuration)
	{
		_categoryService = new CategoryService(configuration);
	}

	// GET: CategoryController
	[HttpGet]
	public ActionResult Index()
	{
		return View(_categoryService.GetAll());
	}

	// GET: CategoryController/Details/5
	[HttpGet]
	public ActionResult Details(int id)
	{
		return View(_categoryService.Get(id));
	}

	// GET: CategoryController/Create
	[HttpGet]
	public ActionResult Create()
	{
		return View();
	}

	// POST: CategoryController/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Create(CategoryViewModel category)
	{
		try
		{
			return RedirectToAction("Details", new { id = _categoryService.Create(category).CategoryId });
		}
		catch
		{
			return View();
		}
	}

	// GET: CategoryController/Edit/5
	[HttpGet]
	public ActionResult Edit(int id)
	{
		return View(_categoryService.Get(id));
	}

	// POST: CategoryController/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Edit(CategoryViewModel category)
	{
		try
		{
			_categoryService.Edit(category);
			return RedirectToAction(nameof(Index));
		}
		catch
		{
			return View();
		}
	}

	// GET: CategoryController/Delete/5
	[HttpGet]
	public ActionResult Delete(int id)
	{
		return View(_categoryService.Get(id));
	}

	// POST: CategoryController/Delete/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Delete(CategoryViewModel category)
	{
		try
		{
			_categoryService.Delete(category.CategoryId);

			return RedirectToAction(nameof(Index));
		}
		catch
		{
			return View();
		}
	}
}