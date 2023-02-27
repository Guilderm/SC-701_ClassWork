using FrontEnd.Services;
using Serilog;
using Serilog.Core;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// configures Serilog.
Logger logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddTransient(typeof(GenericServices<>));
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ShippersService>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler("/Home/Error");


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();