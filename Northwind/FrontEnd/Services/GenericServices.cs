using Newtonsoft.Json;
using Serilog;

namespace FrontEnd.Services;

public class GenericServices<TModel> where TModel : class
{
    private readonly HttpService _httpService;
    private readonly string _resourcePath;

    public GenericServices(IConfiguration configuration, string resourcePath)
    {
        _httpService = new HttpService(configuration);
        _resourcePath = resourcePath;
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
            Log.Error(ex, "Error getting all {Model}s from {_resourcePath}", typeof(TModel), _resourcePath);
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
            Log.Error(ex, "Error getting {Model} with id {id} from {_resourcePath}", typeof(TModel), id, _resourcePath);
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
            Log.Error(ex, "Error creating {Model} on {_resourcePath}", typeof(TModel), _resourcePath);
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
            Log.Error(ex, "Error updating {Model} on {_resourcePath}", typeof(TModel), _resourcePath);
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
            Log.Error(ex, "Error deleting {Model} with id {id} from {_resourcePath}", typeof(TModel), id,
                _resourcePath);
            throw;
        }
    }
}