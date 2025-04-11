using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Fullname, string Address)
        {
            string strOutput = "Xin chào " + Fullname + " đến từ " + Address;
            ViewBag.Message = strOutput;
            return View();
        }
    }
}