using FaxrHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace FaxrHospital.Controllers
{
    public class IllnesController : Controller
    {
        public readonly ApplicationDbContext _db;
        public IllnesController(ApplicationDbContext db) => _db = db;

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var illnes = from a in _db.Illnes select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                illnes = illnes.Where(a => a.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    illnes = illnes.OrderByDescending(a => a.Name);
                    break;
                default:
                    illnes = illnes.OrderBy(a => a.Name);
                    break;
            }
            return View(illnes);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Illnes illnes)
        {
            if (ModelState.IsValid)
            {
                _db.Illnes.Add(illnes);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Illnes? illnesFromDb = _db.Illnes.Find(id);
            if (illnesFromDb == null)
            {
                return NotFound();
            }
            return View(illnesFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Illnes illnes)
        {
            if (ModelState.IsValid)
            {
                _db.Illnes.Update(illnes);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            Illnes? illnesFromDb = _db.Illnes.Find(id);
            if (illnesFromDb == null)
            {
                return NotFound();
            }
            _db.Illnes.Remove(illnesFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
