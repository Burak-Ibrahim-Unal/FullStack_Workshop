using System.Text;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/* I added these lines to ApplicationServiceExtensionS */
// builder.Services.AddScoped<ITokenService, TokenService>();
// builder.Services.AddDbContext<DataContext>(options =>
// {
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
// });

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddControllers();
var myAngularPolicy = "myAngularPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(myAngularPolicy,
                          builder =>
                          {
                              builder.WithOrigins("https://localhost:4200")
                                     .AllowAnyHeader()
                                     .AllowAnyMethod();
                          });
});

builder.Services.AddIdentityServices(builder.Configuration);    

/* I added this lines to IdentityServiceExtensions */
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
//         ValidateIssuer = false,
//         ValidateAudience = false
//     };
// });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseCors(policy=>policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200/"));
app.UseCors(myAngularPolicy);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
