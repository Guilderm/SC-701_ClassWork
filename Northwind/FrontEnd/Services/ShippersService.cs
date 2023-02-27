using FrontEnd.Models;

namespace FrontEnd.Services;

public class ShippersService : GenericServices<ShippersViewModel>
{
    public ShippersService(IConfiguration configuration, ILogger<ShippersService> logger)
        : base(configuration.GetSection("BackendURLs")["ShipperPath"], logger)
    {
    }
}