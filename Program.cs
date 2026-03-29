using BarberShopApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Cấu hình kết nối Database (Giữ nguyên của bạn là đúng)
builder.Services.AddDbContext<BarberShopAppContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Thêm dịch vụ MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 3. Cấu hình Pipeline xử lý yêu cầu
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();

// QUAN TRỌNG: Đảm bảo các file CSS/JS/Images trong wwwroot được tải
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 4. Cấu hình Route mặc định
// Đã sửa thành Account/Login để khi chạy web là hiện trang Đăng nhập ngay
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Account}/{action=Login}/{id?}");

// Nếu bạn dùng .NET 9 và muốn giữ MapStaticAssets thì để dòng này, 
// nếu không thì UseStaticFiles ở trên là đủ.
app.MapStaticAssets();

app.Run();