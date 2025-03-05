using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace MvcMovie.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            // return "This is my default action...";
            return View();
        }

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}