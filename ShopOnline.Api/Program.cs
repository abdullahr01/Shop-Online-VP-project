using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using System.Globalization;
using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

AppContext.SetSwitch("Switch.System.Globalization.Invariant", false);

builder.Services.AddDbContext<ShopOnlineDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopOnlineDbContext"));
});



// Specify the invariant culture

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

app.UseAuthorization();

app.MapControllers();

app.Run();

