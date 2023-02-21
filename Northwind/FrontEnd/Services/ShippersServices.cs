using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Services;

public class ShippersServices
{
    private readonly HttpService _httpService;
    private readonly string _resourcePath;


    public ShippersServices(IConfiguration configuration)
    {
        _httpService = new HttpService(configuration);
        _resourcePath = configuration.GetSection("BackendURLs")["ShipperPath"];
    }

    public List<ShippersViewModel> GetAll()
    {
        HttpResponseMessage responseMessage = _httpService.GetResponse(_resourcePath);
        string content = responseMessage.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<List<ShippersViewModel>>(content);
    }

    public ShippersViewModel Get(int id)
    {
        HttpResponseMessage responseMessage = _httpService.GetResponse(_resourcePath + id);
        string content = responseMessage.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<ShippersViewModel>(content);
    }

    public ShippersViewModel Create(ShippersViewModel Shippers)
    {
        HttpResponseMessage responseMessage = _httpService.PostResponse(_resourcePath, Shippers);
        string content = responseMessage.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<ShippersViewModel>(content);
    }

    public ShippersViewModel Edit(ShippersViewModel Shippers)
    {
        HttpResponseMessage responseMessage = _httpService.PutResponse(_resourcePath, Shippers);
        string content = responseMessage.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<ShippersViewModel>(content);
    }

    public ShippersViewModel Delete(int id)
    {
        HttpResponseMessage responseMessage = _httpService.DeleteResponse(_resourcePath + id);
        string content = responseMessage.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<ShippersViewModel>(content);
    }
}