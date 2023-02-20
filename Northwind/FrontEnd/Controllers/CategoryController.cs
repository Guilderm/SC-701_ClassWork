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
	public ActionResult Index()
	{
		List<CategoryViewModel> categories = _categoryService.GetAll();

		return View(categories);
	}

	// GET: CategoryController/Details/5
	public ActionResult Details(int id)
	{
		CategoryViewModel category = _categoryService.Get(id);

		return View(category);
	}

	// GET: CategoryController/Create
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
			category = _categoryService.Create(category);

			return RedirectToAction("Details", new { id = category.CategoryId });
		}
		catch
		{
			return View();
		}
	}

	// GET: CategoryController/Edit/5
	public ActionResult Edit(int id)
	{
		CategoryViewModel category = _categoryService.Get(id);

		return View(category);
	}

	// POST: CategoryController/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Edit(CategoryViewModel category)
	{
		try
		{
			category = _categoryService.Edit(category);

			return RedirectToAction(nameof(Index));
		}
		catch
		{
			return View();
		}
	}

	// GET: CategoryController/Delete/5
	public ActionResult Delete(int id)
	{
		CategoryViewModel category = _categoryService.Get(id);

		return View(category);
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