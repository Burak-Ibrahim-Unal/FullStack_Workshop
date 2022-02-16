using Application;
using Core.Application.Pipelines.Caching;
using Core.CrossCuttingConcerns.Exceptions;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationServices();
builder.Services.AddSecurityServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



builder.Services.AddDistributedMemoryCache(); // inm memory
//builder.Services.AddStackExchangeRedisCache(options => options.Configuration = "localhost:6379"); // redis
builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection("CacheSettings")); // get cache settings from appsettings.json


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors(options => options.AddDefaultPolicy(b =>
//{​​​​​​
//                    b.AllowAnyOrigin()
//                   .AllowAnyMethod()
//                   .AllowAnyHeader();
//}​​​​​​));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

//app.UseCors();

app.Run();
