using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MvcMovie.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            // return "This is my default action...";
            return View();
        }

        [HttpPost]
        public IActionResult Index(Person ps)
        {
            string strOutput = "Xin chao " + ps.PersonId + "-" + ps.FullName + "-" + ps.Address;
            ViewBag.infoPerson = strOutput;
            return View();
        }
    }
}