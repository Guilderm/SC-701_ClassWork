using FrontEnd.Models;

namespace FrontEnd.Services;

public class CategoryService : GenericServices<CategoryViewModel>
{
    public CategoryService(IConfiguration configuration) : base(
        configuration, configuration.GetSection("BackendURLs")["categoryPath"])
    {
    }
}