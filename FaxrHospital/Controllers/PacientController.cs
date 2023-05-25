using FaxrHospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FaxrHospital.Controllers
{
    public class PacientController : Controller
    {
        public readonly ApplicationDbContext _db;
        public PacientController(ApplicationDbContext db) => _db = db;

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["SexSortParm"] = sortOrder == "Sex" ? "sex_desc" : "Sex";
            ViewData["PassportSortParm"] = sortOrder == "Passport" ? "passport_desc" : "Passport";
            ViewData["PhoneSortParm"] = sortOrder == "Phone" ? "phone_desc" : "Phone";
            ViewData["BirthSortParm"] = sortOrder == "Birth" ? "birth_desc" : "Birth";
            ViewData["AdressSortParm"] = sortOrder == "Adress" ? "adress_desc" : "Adress";


            var pacient = from a in _db.Pacient select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                pacient = pacient.Where(a => a.Name.Contains(searchString) ||
                                             a.Sex.Contains(searchString) ||
                                             a.Passport.Contains(searchString) ||
                                             a.Phone.Contains(searchString) ||
                                             a.Birthday.ToString().Contains(searchString) ||
                                             a.Adress.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    pacient = pacient.OrderByDescending(a => a.Name);
                    break;
                case "Sex":
                    pacient = pacient.OrderBy(s => s.Sex);
                    break;
                case "sex_desc":
                    pacient = pacient.OrderByDescending(s => s.Sex);
                    break;
                case "Passport":
                    pacient = pacient.OrderBy(s => s.Passport);
                    break;
                case "passport_desc":
                    pacient = pacient.OrderByDescending(s => s.Passport);
                    break;
                case "Phone":
                    pacient = pacient.OrderBy(s => s.Phone);
                    break;
                case "phone_desc":
                    pacient = pacient.OrderByDescending(s => s.Phone);
                    break;
                case "Birth":
                    pacient = pacient.OrderBy(s => s.Birthday);
                    break;
                case "birth_desc":
                    pacient = pacient.OrderByDescending(s => s.Birthday);
                    break;
                case "Adress":
                    pacient = pacient.OrderBy(s => s.Adress);
                    break;
                case "adress_desc":
                    pacient = pacient.OrderByDescending(s => s.Adress);
                    break;
                default:
                    pacient = pacient.OrderBy(a => a.Name);
                    break;
            }
            return View(pacient);
        }

        public IActionResult Add()
        {
            IEnumerable<SelectListItem> OtdelenieList = _db.Otdelenie.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.OtdelenieList = OtdelenieList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                _db.Pacient.Add(pacient);
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

            Pacient? pacientFromDb = _db.Pacient.Find(id);
            if (pacientFromDb == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> OtdelenieList = _db.Otdelenie.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.OtdelenieList = OtdelenieList;

            return View(pacientFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                _db.Pacient.Update(pacient);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            Pacient? pacientFromDb = _db.Pacient.Find(id);
            if (pacientFromDb == null)
            {
                return NotFound();
            }
            _db.Pacient.Remove(pacientFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
