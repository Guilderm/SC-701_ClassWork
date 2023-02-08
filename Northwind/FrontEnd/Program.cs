WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
	{
	_ = app.UseExceptionHandler("/Home/Error");
	}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	 name: "default",
	 pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
