using System;
using CarCleanz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;

// Build host and configure services
var builder = WebApplication.CreateBuilder(args);

// Add configuration-based connection string (fallback to local file)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=carcleanz.db";

// Register EF Core with SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Add MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Standard middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();