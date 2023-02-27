using FrontEnd.Models;

namespace FrontEnd.Services;

public class ShippersServices : GenericServices<ShippersViewModel>
{
    public ShippersServices(IConfiguration configuration) : base(configuration,
        configuration.GetSection("BackendURLs")["ShipperPath"])
    {
    }
}