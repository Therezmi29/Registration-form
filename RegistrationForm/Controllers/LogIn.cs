using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RegistrationForm.IoC.Repository;
using RegistrationForm.Models;
using System.Security.Claims;

namespace RegistrationForm.Controllers
{
    public class LogIn : Controller
    {
        private readonly ILogInRepository _LogInRepository;
        public LogIn(ILogInRepository logInRepository)
        {
            _LogInRepository = logInRepository;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LogInViewModel login)
        {
            if(!ModelState.IsValid)
            {
                return View(login);
            }
            var user = _LogInRepository.GetUser(login.Email.ToLower() , login.Password);
            if (user == null)
            {
                ModelState.AddModelError("Email", "Wrong info!");
                return View(login);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),


            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return View("/");
        }
    }
}
