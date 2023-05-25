using FaxrHospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FaxrHospital.Controllers
{
    public class DoctorController : Controller
    {
        public readonly ApplicationDbContext _db;
        public DoctorController(ApplicationDbContext db) => _db = db;

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["SpecSortParm"] = sortOrder == "Spec" ? "spec_desc" : "Spec";
            ViewData["OtdelSortParm"] = sortOrder == "Otdel" ? "otdel_desc" : "Otdel";
            ViewData["QualSortParm"] = sortOrder == "Qual" ? "qual_desc" : "Qual";

            var doctor = from a in _db.Doctor select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                doctor = doctor.Where(a => a.Name.Contains(searchString) ||
                                           a.Speciality.Contains(searchString) || 
                                           a.Qualification.Contains(searchString) || 
                                           a.OtdelenieId.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    doctor = doctor.OrderByDescending(a => a.Name);
                    break;
                case "Spec":
                    doctor = doctor.OrderBy(s => s.Speciality);
                    break;
                case "spec_desc":
                    doctor = doctor.OrderByDescending(s => s.Speciality);
                    break;
                case "Otdel":
                    doctor = doctor.OrderBy(s => s.Otdelenie.Name);
                    break;
                case "otdel_desc":
                    doctor = doctor.OrderByDescending(s => s.Otdelenie.Name);
                    break;
                case "Qual":
                    doctor = doctor.OrderBy(s => s.Qualification);
                    break;
                case "qual_desc":
                    doctor = doctor.OrderByDescending(s => s.Qualification);
                    break;
                default:
                    doctor = doctor.OrderBy(a => a.Name);
                    break;
            }
            return View(doctor);
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
        public IActionResult Add(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _db.Doctor.Add(doctor);
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

            Doctor? doctorFromDb = _db.Doctor.Find(id);
            if (doctorFromDb == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> OtdelenieList = _db.Otdelenie.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.OtdelenieList = OtdelenieList;

            return View(doctorFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _db.Doctor.Update(doctor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            Doctor? doctorFromDb = _db.Doctor.Find(id);
            if (doctorFromDb == null)
            {
                return NotFound();
            }
            _db.Doctor.Remove(doctorFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
