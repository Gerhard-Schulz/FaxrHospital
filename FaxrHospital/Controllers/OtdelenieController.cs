using FaxrHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace FaxrHospital.Controllers
{
    public class OtdelenieController : Controller
    {
        public readonly ApplicationDbContext _db;
        public OtdelenieController(ApplicationDbContext db) => _db = db;

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var otdelenie = from a in _db.Otdelenie select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                otdelenie = otdelenie.Where(a => a.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    otdelenie = otdelenie.OrderByDescending(a => a.Name);
                    break;
                default:
                    otdelenie = otdelenie.OrderBy(a => a.Name);
                    break;
            }
            return View(otdelenie);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Otdelenie otdelenie)
        {
            if (ModelState.IsValid)
            {
                _db.Otdelenie.Add(otdelenie);
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

            Otdelenie? otdelenieFromDb = _db.Otdelenie.Find(id);
            if (otdelenieFromDb == null)
            {
                return NotFound();
            }
            return View(otdelenieFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Otdelenie otdelenie)
        {
            if (ModelState.IsValid)
            {
                _db.Otdelenie.Update(otdelenie);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            Otdelenie? otdelenieFromDb = _db.Otdelenie.Find(id);
            if (otdelenieFromDb == null)
            {
                return NotFound();
            }
            _db.Otdelenie.Remove(otdelenieFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
