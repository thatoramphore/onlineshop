using OnlineShop.Api.Data;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//string connectionString = ConnectionStrings;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<OnlineShopDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<OnlineShopDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("OnlineShopConnection")
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
