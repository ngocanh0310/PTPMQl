using Microsoft.AspNetCore.Mvc;
using BT3HD.Models;

namespace BT3HD.Controllers
{
    public class HoaDonController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int soLuong, double donGia)
        {
            var hoaDon = new HoaDonModel
            {
                SoLuong = soLuong,
                DonGia = donGia
            };

            double thanhTien = hoaDon.ThanhTien();

            ViewBag.SoLuong = soLuong;
            ViewBag.DonGia = donGia;
            ViewBag.ThanhTien = thanhTien;

            return View();
        }
    }
}
