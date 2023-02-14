using BackEnd.Configurations;
using DAL.Interfaces;
using DAL.Repositories;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Insert services to the container.
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));

// configures Serilog.
Serilog.Core.Logger logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers().AddNewtonsoftJson(op
	=> op.SerializerSettings.ReferenceLoopHandling
	= Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
