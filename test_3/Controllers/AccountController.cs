using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using test_3.IRepository;
using test_3.Models;

namespace test_3.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _repository;
        public AccountController(IUserRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model,string returnurl)
        {
          
            try
            {
                User validUser = _repository.IsValid(model);
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, validUser.Name),
                    new Claim(ClaimTypes.Role, validUser.Role)

                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                if (!string.IsNullOrEmpty(returnurl) && Url.IsLocalUrl(returnurl))
                {
                    return LocalRedirect(returnurl);
                }
                return RedirectToAction("Index", "Student");
            }
            catch
            {
                @TempData["errorMsg"] = "Not valid User.";
                return View();
            }

          
        }

        public IActionResult LogOut()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
            
        }
    }
}
