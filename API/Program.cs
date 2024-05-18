using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Practices.Data;
using Microsoft.EntityFrameworkCore;
using Practices.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddScoped<IUserRepository, UserEFRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICompanyRepository, CompanyEFRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();



var connectionString = builder.Configuration.GetConnectionString("ServerDB_dockernet");

builder.Services.AddDbContext<PracticesContext>(options =>
    options.UseSqlServer(connectionString));

// Configurar CORS para permitir todas las solicitudes
builder.Services.AddCors(options =>
{
options.AddPolicy("MyAllowedOrigins",
    policy =>
    {
        policy.WithOrigins("https://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
