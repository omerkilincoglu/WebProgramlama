using B201210597.Models.DTO;
using B201210597.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B201210597.Controllers
{
    public class UserAuthenticationController : Controller
    {

        private readonly IUserAuthenticationService _authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this._authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _authService.LoginAsync(model);
            if (result.StatusCode == 1)
            {

                return RedirectToAction("Display", "Dashboard");
            }
            else

            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }


        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            model.Role = "user";
            var result = await this._authService.RegistrationAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }

       
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this._authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        //[AllowAnonymous]
        //public async Task<IActionResult> RegisterAdmin()
        //{
        //    RegistrationModel model = new RegistrationModel
        //    {
        //        Username = "B201210597@sakarya.edu.tr",
        //        Email = "admin@gmail.com",
        //        Name = "John",

        //        Password = "SAUsau1234@#"
        //    };
        //    model.Role = "admin";
        //    var result = await this._authService.RegistrationAsync(model);
        //    return Ok(result);
        //}
        //[Authorize]
        //public IActionResult ChangePassword()
        //{
        //    return View();
        //}
    }
}
