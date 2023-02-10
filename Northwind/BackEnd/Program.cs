using BackEnd.Configurations;
using DAL.Interfaces;
using DAL.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Insert services to the container.
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers().AddNewtonsoftJson(op
	=> op.SerializerSettings.ReferenceLoopHandling
	= Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
	{
	app.UseSwagger();
	app.UseSwaggerUI();
	}

app.UseAuthorization();

app.MapControllers();

app.Run();
