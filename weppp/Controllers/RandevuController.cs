using B201210597.Models.Domain;
using B201210597.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace B201210597.Controllers
{
    [Authorize(Roles = "admin")]
    public class RandevuController : Controller
    {


        private readonly DatabaseContext _db;


        public RandevuController(DatabaseContext db)
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




            public IActionResult Randevu()
            {

                IEnumerable<Appointment> Opject = _db.Appointments;
                return View(Opject);


            }
            public IActionResult Create()
            {
            var doctors = _db.Doctors.ToList();
            var Kullanici = _db.Kullaniciler.ToList();

            var viewModel = new Appointment
            {
                Doctors = doctors,
                KullaniciLer = Kullanici
            };

            return View(viewModel);

        }

            //POST
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Appointment obj)
            {
                //if (obj.Name == obj.DisplayOrder.ToString())
                //{
                //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
                //}
                //   if (ModelState.IsValid)

                _db.Appointments.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Randevu Eklendi";
                return RedirectToAction("Randevu");


            }

            //GET
            public IActionResult Edit(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var categoryFromDb = _db.Appointments.Find(id);
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
            public IActionResult Edit(Appointment obj)
            {
                //if (obj.Name == obj.DisplayOrder.ToString())
                //{
                //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
                //}

                _db.Appointments.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Randevu Guncelendi";
                return RedirectToAction("Randevu");

            }

            public IActionResult Delete(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var categoryFromDb = _db.Appointments.Find(id);
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
            public IActionResult DeleteOost(int? id)
            {
                var obj = _db.Appointments.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }

                _db.Appointments.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Randevu Silindi";
                return RedirectToAction("Randevu");

            }



        }
    }


