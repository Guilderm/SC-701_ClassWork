using FrontEnd.Models;

namespace FrontEnd.Services;

public class CategoryService : GenericServices<CategoryViewModel>
{
    public CategoryService(IConfiguration configuration, ILogger<CategoryService> logger)
        : base(configuration.GetSection("BackendURLs")["categoryPath"], logger)
    {
    }
}