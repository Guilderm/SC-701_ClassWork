using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenericControllers<TEntity, TModel> : ControllerBase
    where TEntity : class, new()
    where TModel : class, new()
{
    private readonly ILogger<GenericControllers<TEntity, TModel>> _logger;
    protected readonly IMapper Mapper;
    protected readonly IGenericRepository<TEntity> Repository;
    protected readonly IUnitOfWork UnitOfWork;

    public GenericControllers(IUnitOfWork unitOfWork, IMapper mapper)
    {
        try
        {
            UnitOfWork = unitOfWork;
            Repository = UnitOfWork.GetRepository<TEntity>();
            Mapper = mapper;
            _logger = new LoggerFactory().CreateLogger<GenericControllers<TEntity, TModel>>();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while initializing the GenericControllers.");
            throw;
        }
    }

    #region POST|Create - Used to create a new resource.

    [HttpPost]
    public virtual IActionResult Post([FromBody] TModel requestDto)
    {
        try
        {
            _logger.LogInformation($"Registration Attempt for {requestDto} ");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Invalid POST attempt in {nameof(requestDto)}");
                return BadRequest(ModelState);
            }

            TEntity? mappedResult = Mapper.Map<TEntity>(requestDto);

            Repository.Insert(mappedResult);
            UnitOfWork.SaveChanges();

            return Ok(mappedResult);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating a new resource.");
            throw;
        }
    }

    #endregion

    #region PUT|Update - Used to update an existing resource.

    [HttpPut]
    public IActionResult Put([FromBody] TModel requestDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Invalid PUT attempt in {nameof(requestDto)}");
                return BadRequest(ModelState);
            }

            TEntity? mappedResult = Mapper.Map<TEntity>(requestDto);
            Repository.Update(mappedResult);
            UnitOfWork.SaveChanges();

            return Ok(mappedResult);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating an existing resource.");
            throw;
        }
    }

    #endregion

    #region PATCH|Update - Used to partially update an existing resource.

    [HttpPatch]
    public IActionResult Patch()
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while partially updating an existing resource.");
            throw;
        }
    }

    #endregion

    #region DELETE|Delete - Used to delete a resource.

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Invalid DELETE attempt with {nameof(id)} {id}");
                return BadRequest(ModelState);
            }

            TEntity dbResult = Repository.Get(id);
            Repository.Remove(dbResult);
            UnitOfWork.SaveChanges();

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting a resource.");
            throw;
        }
    }

    #endregion

    #region GET|Read - Used to retrieve a resource or a collection of resources.

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<TEntity> dbResult = Repository.GetAll();
            IList<TModel>? mappedResult = Mapper.Map<IList<TModel>>(dbResult);
            return Ok(mappedResult);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving resources.");
            return StatusCode(500);
        }
    }

    #endregion
}