using Microsoft.AspNetCore.Mvc;

namespace BT2DMH.Controllers
{
    public class DiemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string monHoc, double diemA, double diemB, double diemC)
        {
            double diemTongKet = (diemA * 0.6) + (diemB * 0.3) + (diemC * 0.1);
            string ketLuan;

            if (diemTongKet >= 8.5)
                ketLuan = "Giỏi";
            else if (diemTongKet >= 7)
                ketLuan = "Khá";
            else if (diemTongKet >= 5)
                ketLuan = "Trung bình";
            else
                ketLuan = "Yếu";

            ViewBag.MonHoc = monHoc;
            ViewBag.DiemTongKet = diemTongKet;
            ViewBag.KetLuan = ketLuan;

            return View();
        }
    }
}
