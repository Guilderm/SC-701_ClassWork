using FrontEnd.Models;

namespace FrontEnd.Services;

public class ShippersService : GenericServices<ShippersViewModel>
{
    public ShippersService(IConfiguration configuration) : base(configuration,
        configuration.GetSection("BackendURLs")["ShipperPath"])
    {
    }
}