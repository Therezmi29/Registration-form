using Microsoft.AspNetCore.Mvc;
using RegistrationForm.IoC.Repository;
using RegistrationForm.Models;
using System.Diagnostics;

namespace RegistrationForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISignUpRepository _signUpRepository;

        public HomeController(ILogger<HomeController> logger, ISignUpRepository signUpRepository)
        {
            _logger = logger;
            _signUpRepository = signUpRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SignUpViewModell register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            if (_signUpRepository.IsExistUserByEmail(register.Email.ToLower()) && _signUpRepository.IsExistUserByUsername(register.UserName))
            {
                return View(register);
            }
            User user = new User()
            {
                UserName = register.UserName,
                Email = register.Email,
                Password = register.Password,
                RegisterDate = DateTime.Now,
            };
            _signUpRepository.AddUser(user);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}