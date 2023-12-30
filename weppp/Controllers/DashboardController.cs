using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B201210597.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Display()
        {


            if (User.IsInRole("admin"))
            {

                return RedirectToAction("Display", "Admin");
            
            }
            return View();
        }
    }
}
