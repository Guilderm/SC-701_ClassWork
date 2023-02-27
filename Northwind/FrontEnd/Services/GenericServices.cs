using Newtonsoft.Json;

namespace FrontEnd.Services;

public class GenericServices<TModel> where TModel : class
{
    private readonly HttpService _httpService;
    private readonly ILogger _logger;
    private readonly string _resourcePath;

    public GenericServices(string resourcePath, ILogger logger)
    {
        _httpService = new HttpService();
        _resourcePath = resourcePath ?? throw new ArgumentNullException(nameof(resourcePath));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public List<TModel> GetAll()
    {
        try
        {
            HttpResponseMessage responseMessage = _httpService.GetResponse(_resourcePath);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<TModel>>(content);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all {Model}s from {_resourcePath}", typeof(TModel), _resourcePath);
            throw;
        }
    }

    public TModel Get(int id)
    {
        try
        {
            HttpResponseMessage responseMessage = _httpService.GetResponse(_resourcePath + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TModel>(content);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting {Model} with id {id} from {_resourcePath}", typeof(TModel), id,
                _resourcePath);
            throw;
        }
    }

    public TModel Create(TModel obj)
    {
        try
        {
            HttpResponseMessage responseMessage = _httpService.PostResponse(_resourcePath, obj);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TModel>(content);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating {Model} on {_resourcePath}", typeof(TModel), _resourcePath);
            throw;
        }
    }

    public TModel Edit(TModel obj)
    {
        try
        {
            HttpResponseMessage responseMessage = _httpService.PutResponse(_resourcePath, obj);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TModel>(content);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating {Model} on {_resourcePath}", typeof(TModel), _resourcePath);
            throw;
        }
    }

    public TModel Delete(int id)
    {
        try
        {
            HttpResponseMessage responseMessage = _httpService.DeleteResponse(_resourcePath + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TModel>(content);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting {Model} with id {id} from {_resourcePath}", typeof(TModel), id,
                _resourcePath);
            throw;
        }
    }
}