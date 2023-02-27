using FrontEnd.Models;

namespace FrontEnd.Services;

public class ShippersService : GenericServices<ShippersViewModel>
{
    public ShippersService(ILogger<ShippersService> logger, IConfiguration configuration)
        : base(configuration.GetSection("BackendURLs")["ShipperPath"], logger)
    {
    }
}