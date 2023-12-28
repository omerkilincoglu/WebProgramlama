using B201210597.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace B201210597.Controllers


{
    [Authorize(Roles = "admin")]

    public class DepartmentsController : Controller
    {

        private readonly DatabaseContext _db;

        public DepartmentsController(DatabaseContext db)
        {
            _db = db;
        }
        public IActionResult cikis()
        {
            return RedirectToAction("Logout", "UserAuthentication");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}



