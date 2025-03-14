using DemoMovieMovie.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMovieMovie.Controllers
{
    public class DaiLyController : Controller
    {
        // Hiển thị form nhập dữ liệu
        public IActionResult Create()
        {
            return View();
        }

        // Nhận dữ liệu từ View khi submit form
        [HttpPost]
        public IActionResult Create(DaiLy daiLy)
        {
            if (ModelState.IsValid)
            {
                // Giả lập lưu vào CSDL (ở đây chỉ tạm lưu vào ViewBag)
                ViewBag.Message = $"Đại lý {daiLy.TenDaiLy} được thêm thành công!";
                return View("Details", daiLy); // Chuyển hướng sang View Details để hiển thị
            }

            return View(daiLy); // Nếu lỗi, giữ lại dữ liệu cũ trên form
        }

        // Hiển thị dữ liệu nhận được từ Controller
        public IActionResult Details(DaiLy daiLy)
        {
            return View(daiLy);
        }
    }
}
