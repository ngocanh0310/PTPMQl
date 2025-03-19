using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using System.Threading.Tasks;
using System.Linq;

namespace MvcMovie.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách Person
        public async Task<IActionResult> Index()
        {
            return View(await _context.Persons.ToListAsync());
        }

        // Hiển thị form tạo Person
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý dữ liệu từ form tạo Person
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FullName,Address")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Persons.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // Hiển thị form chỉnh sửa Person
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
                return NotFound();

            return View(person);
        }

        // Xử lý dữ liệu từ form chỉnh sửa Person
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("PersonId,FullName,Address")] Person person)
        {
            if (id == null || person.PersonId == null || id.Value.ToString() != person.PersonId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // Xác nhận xóa Person
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
                return NotFound();

            return View(person);
        }

        // Xóa Person khỏi Database
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(string id)
        {
            return !string.IsNullOrEmpty(id) && _context.Persons.Any(e => e.PersonId == id);
        }
    }
}
