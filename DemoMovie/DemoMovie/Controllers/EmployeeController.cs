using DemoMovie.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMovie.Controllers
{
    public class EmployeeController : Controller
    {
        // Hiển thị form nhập thông tin nhân viên
        public IActionResult Create()
        {
            return View();
        }

        // Nhận dữ liệu từ View khi submit form
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Giả lập lưu dữ liệu vào ViewBag
                ViewBag.Message = $"Nhân viên {employee.FullName} đã được thêm thành công!";
                return View("Details", employee); // Chuyển hướng đến trang chi tiết
            }

            return View(employee);
        }

        // Hiển thị chi tiết nhân viên
        public IActionResult Details(Employee employee)
        {
            return View(employee);
        }
    }
}
