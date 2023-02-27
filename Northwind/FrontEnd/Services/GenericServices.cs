using Newtonsoft.Json;

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
        HttpResponseMessage responseMessage = _httpService.GetResponse(_resourcePath);
        string content = responseMessage.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<List<TModel>>(content);
    }

    public TModel Get(int id)
    {
        HttpResponseMessage responseMessage = _httpService.GetResponse(_resourcePath + id);
        string content = responseMessage.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<TModel>(content);
    }

    public TModel Create(TModel obj)
    {
        HttpResponseMessage responseMessage = _httpService.PostResponse(_resourcePath, obj);
        string content = responseMessage.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<TModel>(content);
    }

    public TModel Edit(TModel obj)
    {
        HttpResponseMessage responseMessage = _httpService.PutResponse(_resourcePath, obj);
        string content = responseMessage.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<TModel>(content);
    }

    public TModel Delete(int id)
    {
        HttpResponseMessage responseMessage = _httpService.DeleteResponse(_resourcePath + id);
        string content = responseMessage.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<TModel>(content);
    }
}