using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private ICategoryDAL _categoryDAL;
        
        
        #region Constructor
        public CategoryController()
        {
            _categoryDAL = new CategoryDALImpl(new Entities.DBContext());

        }
        #endregion

        #region Get's
        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Category> categories = _categoryDAL.GetAll();


            return new JsonResult(categories);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Category category;
            category = _categoryDAL.Get(id);


            return new JsonResult(category);

        }
        #endregion

        #region Agregar
        // POST api/<CategoryController>
        [HttpPost]
        public JsonResult Post([FromBody] Category category)
        {
            _categoryDAL.Add(category);
            return new JsonResult(category);

        }

        #endregion

                #region MOdificar
        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] Category category)
        {

            _categoryDAL.Update(category);
            return new JsonResult(category);    

        }
        #endregion

        #region Eliminar
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Category category = new Category { CategoryId= id };
            _categoryDAL.Remove(category);

            return new  JsonResult(category);


        }


        #endregion
    }
}
