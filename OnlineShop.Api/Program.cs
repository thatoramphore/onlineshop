using OnlineShop.Api.Data;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Api.Repositories.Contracts;
using OnlineShop.Api.Entities;
using OnlineShop.Api.Repositories;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
//string connectionString = ConnectionStrings;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<OnlineShopDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContextPool<OnlineShopDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("OnlineShopConnection")
));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => 
    policy.WithOrigins("https://localhost:7210", "http://localhost:7210")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
