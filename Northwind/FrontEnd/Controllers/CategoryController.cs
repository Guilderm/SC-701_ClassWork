using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers;

public class CategoryController : Controller
{
	private CategoryHelper _categoryHelper;

	// GET: CategoryController
	public ActionResult Index()
	{
		_categoryHelper = new CategoryHelper();
		List<CategoryViewModel> lista = _categoryHelper.GetAll();

		return View(lista);
	}

	// GET: CategoryController/Details/5
	public ActionResult Details(int id)
	{
		_categoryHelper = new CategoryHelper();
		CategoryViewModel category = _categoryHelper.Get(id);

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
			_categoryHelper = new CategoryHelper();
			category = _categoryHelper.Create(category);

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
		_categoryHelper = new CategoryHelper();
		CategoryViewModel category = _categoryHelper.Get(id);

		return View(category);
	}

	// POST: CategoryController/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Edit(CategoryViewModel category)
	{
		try
		{
			CategoryHelper categoryHelper = new();
			category = categoryHelper.Edit(category);


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
		_categoryHelper = new CategoryHelper();
		CategoryViewModel category = _categoryHelper.Get(id);

		return View(category);
	}

	// POST: CategoryController/Delete/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Delete(CategoryViewModel category)
	{
		try
		{
			_categoryHelper = new CategoryHelper();
			_categoryHelper.Delete(category.CategoryId);


			return RedirectToAction(nameof(Index));
		}
		catch
		{
			return View();
		}
	}
}