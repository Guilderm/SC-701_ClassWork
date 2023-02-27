using FrontEnd.Models;

namespace FrontEnd.Services;

public class CategoryService : GenericServices<CategoryViewModel>
{
    public CategoryService(ILogger<CategoryService> logger, IConfiguration configuration)
        : base(configuration.GetSection("BackendURLs")["categoryPath"], logger)
    {
    }
}