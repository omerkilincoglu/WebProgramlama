using B201210597.Models.Domain;
using B201210597.Models.DTO;
using B201210597.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace B201210597.Controllers
{
    [Authorize(Roles = "admin")]

    public class KullaniciController : Controller
    {
		private readonly IUserAuthenticationService _authService;
		private readonly DatabaseContext _db;

		public KullaniciController(IUserAuthenticationService authService, DatabaseContext dbContext)
		{
			this._authService = authService;
			this._db = dbContext;
		}


		public IActionResult cikis()
        {
            return RedirectToAction("Logout", "UserAuthentication");
        }

        public IActionResult Kullanici()
        {

            IEnumerable<Kullanici> Opject = _db.Kullaniciler;
            return View(Opject);


        }
        public IActionResult CreateKullanici()
        {
            
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateKullanici(Kullanici obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            //   if (ModelState.IsValid)

            _db.Kullaniciler.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Kullanici başaryla Kaydedildi";
            return RedirectToAction("Kullanici");


        }

        public IActionResult EditKullanici(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Kullaniciler.Find(id);
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
        public IActionResult EditKullanici(Kullanici obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}

            _db.Kullaniciler.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Kullanici updated successfully";
            return RedirectToAction("Kullanici");

        }
        public IActionResult DeleteKullanici(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Kullaniciler.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        public IActionResult Index()
        {
            IEnumerable<Kullanici> Opject = _db.Kullaniciler;
            return View(Opject);

        }

        [HttpPost, ActionName("DeleteKullanici")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePostKullanici(int? id)
        {
            var obj = _db.Kullaniciler.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Kullaniciler.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Kullanici Kaydi Silindi";
            return RedirectToAction("Kullanici");

        }



    }
}

