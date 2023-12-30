using B201210597.Models.Domain;
using B201210597.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B201210597.Controllers
{
    [Authorize(Roles = "admin")]
    public class KlinikController : Controller
    {
        private readonly DatabaseContext _db;

        public KlinikController(DatabaseContext db)
        {
            _db = db;
        }
        public IActionResult cikis()
        {
            return RedirectToAction("Logout", "UserAuthentication");
        }
        public IActionResult Display()
        {
            return View();
        }




        public IActionResult Index()
        {

            IEnumerable<Clinic> Opject = _db.Clinics;
            return View(Opject);


        }
        public IActionResult Create()
        {
            Clinic X= new Clinic();
            X.Departments = _db.Departments.ToList();
            return View(X);

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Clinic obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            //   if (ModelState.IsValid)

            _db.Clinics.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Klinik Eklendi";
            return RedirectToAction("Index");


        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Clinics.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Clinic obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}

            _db.Clinics.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Klinik updated successfully";
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Clinics.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Clinics.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Clinics.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Klinik deleted successfully";
            return RedirectToAction("Index");

        }



    }
}
