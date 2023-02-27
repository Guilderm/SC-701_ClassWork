using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers;

public class CategoryController : Controller
{
    private readonly CategoryService _categoryService;
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(CategoryService categoryService, ILogger<CategoryController> logger)
    {
        _categoryService = categoryService;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Index()
    {
        _logger.LogInformation("Retrieving all categories.");
        return View(_categoryService.GetAll());
    }

    [HttpGet]
    public ActionResult Details(int id)
    {
        _logger.LogInformation($"Retrieving details for category with ID: {id}.");
        return View(_categoryService.Get(id));
    }

    [HttpGet]
    public ActionResult Create()
    {
        _logger.LogInformation("Rendering category create form.");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CategoryViewModel category)
    {
        try
        {
            _logger.LogInformation("Attempting to create a new category.");
            CategoryViewModel createdCategory = _categoryService.Create(category);
            _logger.LogInformation($"Created category with ID: {createdCategory.CategoryId}");
            return RedirectToAction("Details", new { id = createdCategory.CategoryId });
        }
        catch
        {
            _logger.LogError("An error occurred while creating a new category.");
            return View();
        }
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        _logger.LogInformation($"Rendering category edit form for category with ID: {id}.");
        return View(_categoryService.Get(id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(CategoryViewModel category)
    {
        try
        {
            _logger.LogInformation($"Attempting to update category with ID: {category.CategoryId}.");
            _categoryService.Edit(category);
            _logger.LogInformation($"Updated category with ID: {category.CategoryId}.");
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            _logger.LogError($"An error occurred while updating category with ID: {category.CategoryId}.");
            return View();
        }
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        _logger.LogInformation($"Rendering category delete form for category with ID: {id}.");
        return View(_categoryService.Get(id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(CategoryViewModel category)
    {
        try
        {
            _logger.LogInformation($"Attempting to delete category with ID: {category.CategoryId}.");
            _categoryService.Delete(category.CategoryId);
            _logger.LogInformation($"Deleted category with ID: {category.CategoryId}.");
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            _logger.LogError($"An error occurred while deleting category with ID: {category.CategoryId}.");
            return View();
        }
    }
}