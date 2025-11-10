using CarCleanz.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ? Use the PORT provided by Render (default to 8080 for local run)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

// ? SQLite database file stored in /tmp for Render
var connectionString = "Data Source=/tmp/carcleanz.db";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// ? Add MVC + Session
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// ? Ensure database created at startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
}

// ? Configure HTTP pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ? Don't use HTTPS redirection — Render already handles SSL externally
// app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ? Listen on the correct port for Render
app.Run($"http://0.0.0.0:{port}");