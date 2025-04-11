using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Models.Process;
using OfficeOpenXml;
using System.Data;

namespace MvcMovie.Controllers
{
    public class PersonController : Controller
    {
        private static List<Person> _people = new List<Person>();
        private readonly ExcelProcess _excelProcess = new ExcelProcess();

        public IActionResult Index()
        {
            return View(_people);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Person p)
        {
            if (ModelState.IsValid)
            {
                _people.Add(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public IActionResult Edit(int id)
        {
            var p = _people.FirstOrDefault(x => x.Id == id);
            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(Person p)
        {
            var person = _people.FirstOrDefault(x => x.Id == p.Id);
            if (person != null)
            {
                person.FullName = p.FullName;
                person.Age = p.Age;
                person.Address = p.Address;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var p = _people.FirstOrDefault(x => x.Id == id);
            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var p = _people.FirstOrDefault(x => x.Id == id);
            if (p != null) _people.Remove(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Import() => View();

        [HttpPost]
        public IActionResult Import(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using var stream = new MemoryStream();
                file.CopyTo(stream);
                using var package = new ExcelPackage(stream);
                DataTable dt = _excelProcess.ExcelToDataTable(package);

                _people.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    _people.Add(new Person
                    {
                        Id = int.TryParse(row[0]?.ToString(), out int id) ? id : 0,
                        FullName = row[1]?.ToString() ?? string.Empty,
                        Age = int.TryParse(row[2]?.ToString(), out int age) ? age : 0,
                        Address = row[3]?.ToString() ?? string.Empty
                    });
                }
                return RedirectToAction("Index");
            }
            ViewBag.Error = "Vui lòng chọn file Excel hợp lệ.";
            return View();
        }
    }
}
