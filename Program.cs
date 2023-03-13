using Microsoft.EntityFrameworkCore;
using CarSales.Data;
using AutoMapper;
using CarSales.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("UserData")));

builder.Services.AddDbContext<CarsDbContext>(options =>
options.UseSqlServer(builder.Configuration.
GetConnectionString("Default")));

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IVehicleRepositery, VehicleRepositery>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
