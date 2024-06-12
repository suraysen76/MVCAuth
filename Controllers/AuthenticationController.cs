using MVCAuth.Models;
using Microsoft.AspNetCore.Mvc;
using MVCAuth.Models;
using MVCAuth.Services;
using MVCAuth.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace MVCAuth.wwwroot
{
    public class AuthenticationController : Controller
    {
        private IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //Authenticate User
                var authenticated = _authService.AuthenticateUser(model);
                if (authenticated)
                {
                    HttpContext.Session.SetString("UserAuthenticated", "true");
                    HttpContext.Session.SetString("UserName", model.UserName);
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.LoginErrorMsg = "Invalid UserName or Password";
                return View(model);

            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                //Authenticate User
                var registered = _authService.RegisterUser(model);
                if (registered)
                {
                    HttpContext.Session.SetString("UserAuthenticated", "true");
                    HttpContext.Session.SetString("UserName", model.UserName);

                    return RedirectToAction("Index", "Home");
                   
                }
                ViewBag.RegisterErrorMsg = "Register Failed";
                return View(model);

            }
            return View();
        }

        public IActionResult Logout()
        {
            var userName=HttpContext.Session.GetString("UserName");
            HttpContext.Session.Clear();
            return View(model: userName);
        }

        public IActionResult Profile()
        {
            var userName = HttpContext.Session.GetString("UserName");
            var userModel = _authService.GetProfile(userName);
            return View(userModel);
        }

    }
}
