using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryDAL _categoryDAL;

        public CategoryController()
        {
            _categoryDAL = new CategoryDALImpl(new DBContext());
        }

        #region HttpGet
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Category> categories = _categoryDAL.GetAll();

            return new JsonResult(categories);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Category category;
            category = _categoryDAL.Get(id);

            return new JsonResult(category);
        }
        #endregion

        #region HttpPost
        [HttpPost]
        public JsonResult Post([FromBody] Category category)
        {
            _ = _categoryDAL.Add(category);

            return new JsonResult(category);
        }
        #endregion

        #region HttpPut
        [HttpPut]
        public JsonResult Put([FromBody] Category category)
        {
            _ = _categoryDAL.Update(category);

            return new JsonResult(category);
        }
        #endregion

        #region HttpDelete
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Category category = new() { CategoryId = id };
            _ = _categoryDAL.Remove(category);

            return new JsonResult(category);
        }
        #endregion
    }
}
