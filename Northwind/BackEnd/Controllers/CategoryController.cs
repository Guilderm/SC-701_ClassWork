using DAL.Interfaces;
using DAL.Repositories;

using Entities;

using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController()
    {
        _categoryRepository = new CategoryRepository(new DBContext());
    }

    #region HttpGet
    [HttpGet]
    public JsonResult Get()
    {
        IEnumerable<Category> categories = _categoryRepository.GetAll();

        return new JsonResult(categories);
    }

    [HttpGet("{id}")]
    public JsonResult Get(int id)
    {
        Category category;
        category = _categoryRepository.Get(id);

        return new JsonResult(category);
    }
    #endregion

    #region HttpPost
    [HttpPost]
    public JsonResult Post([FromBody] Category category)
    {
        _ = _categoryRepository.Add(category);

        return new JsonResult(category);
    }
    #endregion

    #region HttpPut
    [HttpPut]
    public JsonResult Put([FromBody] Category category)
    {
        _ = _categoryRepository.Update(category);

        return new JsonResult(category);
    }
    #endregion

    #region HttpDelete
    [HttpDelete("{id}")]
    public JsonResult Delete(int id)
    {
        Category category = new() { CategoryId = id };
        _ = _categoryRepository.Remove(category);

        return new JsonResult(category);
    }
    #endregion
}