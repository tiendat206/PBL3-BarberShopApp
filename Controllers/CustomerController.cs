using Microsoft.AspNetCore.Mvc;
using BarberShopApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BarberShopApp.Controllers
{
	public class CustomerController : Controller
	{
		// Sửa tên từ BarberShopAppDbContext thành BarberShopAppContext
		private readonly BarberShopAppContext _context;

		public CustomerController(BarberShopAppContext context)
		{
			_context = context;
		}

		// Trang chủ của Khách hàng
		public IActionResult Index()
		{
			// Lấy đại diện 1 khách hàng từ DB để test giao diện
			var customer = _context.Customers.FirstOrDefault();

			if (customer == null)
			{
				// Nếu chưa có khách hàng nào trong DB, tạm thời quay lại Login
				return RedirectToAction("Index", "Account");
			}

			return View(customer);
		}
	}
}