//using FaxrHospital.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace FaxrHospital.Controllers
//{
//    public class IllnesHistoryContriller : Controller
//    {
//        public readonly ApplicationDbContext _db;
//        public IllnesHistoryContriller(ApplicationDbContext db) => _db = db;

//        public IActionResult Index(string searchString)
//        {
//            List<>
//                //Хочу сделать главную страницу со списком пациентов и поиском, чтоб моно было нажать, и открылись все его истории болезней (с сортировкой и поиском)
//                //+ подробные данные о всех них сделать на отдельной странице. Ну и конечно полную инфу о пациенте. (Потом как-нибудь)
//        }

//        public IActionResult Card(string sortOrder, string searchString)
//        {
//            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
//            ViewData["SpecSortParm"] = sortOrder == "Spec" ? "spec_desc" : "Spec";
//            ViewData["OtdelSortParm"] = sortOrder == "Otdel" ? "otdel_desc" : "Otdel";
//            ViewData["QualSortParm"] = sortOrder == "Qual" ? "qual_desc" : "Qual";

//            var illnesHistory = from a in _db.IllnesHistory select a;

//            if (!String.IsNullOrEmpty(searchString))
//            {
//                illnesHistory = illnesHistory.Where(a => a.Name.Contains(searchString) ||
//                                           a.Speciality.Contains(searchString) ||
//                                           a.Qualification.Contains(searchString) ||
//                                           a.OtdelenieId.ToString().Contains(searchString));
//            }

//            switch (sortOrder)
//            {
//                case "name_desc":
//                    illnesHistory = illnesHistory.OrderByDescending(a => a.Name);
//                    break;
//                case "Spec":
//                    illnesHistory = illnesHistory.OrderBy(s => s.Speciality);
//                    break;
//                case "spec_desc":
//                    illnesHistory = illnesHistory.OrderByDescending(s => s.Speciality);
//                    break;
//                case "Otdel":
//                    illnesHistory = illnesHistory.OrderBy(s => s.Otdelenie.Name);
//                    break;
//                case "otdel_desc":
//                    illnesHistory = illnesHistory.OrderByDescending(s => s.Otdelenie.Name);
//                    break;
//                case "Qual":
//                    illnesHistory = illnesHistory.OrderBy(s => s.Qualification);
//                    break;
//                case "qual_desc":
//                    illnesHistory = illnesHistory.OrderByDescending(s => s.Qualification);
//                    break;
//                default:
//                    illnesHistory = illnesHistory.OrderBy(a => a.Name);
//                    break;
//            }
//            return View(illnesHistory);
//        }

//        public IActionResult Add()
//        {
//            IEnumerable<SelectListItem> PacientList = _db.Pacient.ToList().Select(u => new SelectListItem
//            {
//                Text = u.Name,
//                Value = u.Id.ToString()
//            });
//            ViewBag.PacientList = PacientList;

//            IEnumerable<SelectListItem> IllnesList = _db.Illnes.ToList().Select(u => new SelectListItem
//            {
//                Text = u.Name,
//                Value = u.Id.ToString()
//            });
//            ViewBag.IllnesList = IllnesList;

//            IEnumerable<SelectListItem> DoctorList = _db.Doctor.ToList().Select(u => new SelectListItem
//            {
//                Text = u.Name,
//                Value = u.Id.ToString()
//            });
//            ViewBag.DoctorList = DoctorList;

//            return View();
//        }

//        [HttpPost]
//        public IActionResult Add(IllnesHistory illnesHistory)
//        {
//            if (ModelState.IsValid)
//            {
//                _db.IllnesHistory.Add(illnesHistory);
//                _db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View();
//        }

//        public IActionResult Edit(int? id)
//        {
//            if (id == null || id == 0)
//            {
//                return NotFound();
//            }

//            IllnesHistory? illnesHistoryFromDb = _db.IllnesHistory.Find(id);
//            if (illnesHistoryFromDb == null)
//            {
//                return NotFound();
//            }

//            IEnumerable<SelectListItem> PacientList = _db.Pacient.ToList().Select(u => new SelectListItem
//            {
//                Text = u.Name,
//                Value = u.Id.ToString()
//            });
//            ViewBag.PacientList = PacientList;

//            IEnumerable<SelectListItem> IllnesList = _db.Illnes.ToList().Select(u => new SelectListItem
//            {
//                Text = u.Name,
//                Value = u.Id.ToString()
//            });
//            ViewBag.IllnesList = IllnesList;

//            IEnumerable<SelectListItem> DoctorList = _db.Doctor.ToList().Select(u => new SelectListItem
//            {
//                Text = u.Name,
//                Value = u.Id.ToString()
//            });
//            ViewBag.DoctorList = DoctorList;

//            return View(illnesHistoryFromDb);
//        }

//        [HttpPost]
//        public IActionResult Edit(IllnesHistory illnesHistory)
//        {
//            if (ModelState.IsValid)
//            {
//                _db.IllnesHistory.Update(illnesHistory);
//                _db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View();
//        }

//        public IActionResult Delete(int? id)
//        {
//            IllnesHistory? illnesHistoryFromDb = _db.IllnesHistory.Find(id);
//            if (illnesHistoryFromDb == null)
//            {
//                return NotFound();
//            }
//            _db.IllnesHistory.Remove(illnesHistoryFromDb);
//            _db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//    }
//}
