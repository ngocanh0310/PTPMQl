using DemoMovieMovie.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMovieMovie.Controllers
{
    public class HeThongPhanPhoiController : Controller
    {
        // Hiển thị form nhập liệu
        public IActionResult Index()
        {
            return View();
        }

        // Nhận dữ liệu từ form gửi lên
        [HttpPost]
        public IActionResult Index(HeThongPhanPhoi model)
        {
            if (ModelState.IsValid)
            {
                // Gửi dữ liệu từ Controller về View để hiển thị
                ViewBag.Message = "Dữ liệu đã được gửi thành công!";
                return View("Result", model);
            }
            return View(model);
        }

        // Hiển thị dữ liệu từ Controller gửi về View
        public IActionResult ShowData()
        {
            var data = new HeThongPhanPhoi
            {
                MaHTPP = "HT01",
                TenHTPP = "Hệ thống phân phối miền Bắc"
            };

            return View("Result", data);
        }
    }
}
