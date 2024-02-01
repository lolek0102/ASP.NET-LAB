using Labolatorium_3_8.Data;
using Labolatorium_3_8.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddRazorPages();                         // doda�
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddDefaultIdentity<IdentityUser>()       // doda�
    .AddRoles<IdentityRole>()                             //
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();
builder.Services.AddScoped<IProductService, ProductService>();
var dbPath = Path.Combine(builder.Environment.ContentRootPath, "Product.db");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Product.db"));


builder.Services.AddMemoryCache();                        // doda�
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseMiddleware<LastVisitCookie>();
app.UseAuthentication();                                 // doda�
app.UseAuthorization();                                  // doda�
app.UseSession();                                        // doda� 
app.MapRazorPages();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
