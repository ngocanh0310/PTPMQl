using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Kết nối CSDL SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🔧 Middleware cho môi trường production
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// ✅ Cho phép truy cập file tĩnh như CSS, JS, file Excel...
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// ✅ Định tuyến mặc định: HomeController nếu không có Controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
