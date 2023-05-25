using FaxrHospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FaxrHospital.Controllers
{
    public class DrugController : Controller
    {
        public readonly ApplicationDbContext _db;
        public DrugController(ApplicationDbContext db) => _db = db;

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["IllnesSortParm"] = sortOrder == "Illnes" ? "illnes_desc" : "Illnes";

            var drug = from a in _db.Drug select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                drug = drug.Where(a => a.Name.Contains(searchString) || a.IllnesId.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    drug = drug.OrderByDescending(a => a.Name);
                    break;
                case "Illnes":
                    drug = drug.OrderBy(s => s.IllnesId);
                    break;
                case "illnes_desc":
                    drug = drug.OrderByDescending(s => s.IllnesId);
                    break;
                default:
                    drug = drug.OrderBy(a => a.Name);
                    break;
            }
            return View(drug);
        }

        public IActionResult Add()
        {
            IEnumerable<SelectListItem> IllnesList = _db.Illnes.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.IllnesList = IllnesList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Drug drug)
        {
            if (ModelState.IsValid)
            {
                _db.Drug.Add(drug);
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

            Drug? drugFromDb = _db.Drug.Find(id);
            if (drugFromDb == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> IllnesList = _db.Illnes.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.IllnesList = IllnesList;

            return View(drugFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Drug drug)
        {
            if (ModelState.IsValid)
            {
                _db.Drug.Update(drug);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            Drug? drugFromDb = _db.Drug.Find(id);
            if (drugFromDb == null)
            {
                return NotFound();
            }
            _db.Drug.Remove(drugFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
