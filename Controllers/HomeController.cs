using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DevWebsCourseProjectApp.Models;
using DevWebsCourseProjectApp.ViewModels;
using System.Threading.Tasks;

namespace DevWebsCourseProjectApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // LOGIN VALIDATION
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authenticate(LoginViewModel model)
        {
            if (ModelState.IsValid)// if vallidation passes
            {
                return RedirectToAction("Index", "LoggedIn"); // take user to logged in page
            }
            else
            {
                return RedirectToAction("Index", "Home"); // else return to login page
            }
        }

        // REGISTER
        public IActionResult Register()
        {
            return View();
        }

        // REGISTER
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            return View();
        }

        // RESET PASSWORD
        public IActionResult ResetPassword()
        {
            return View();
        }

        // RESET PASSWORD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(RegisterViewModel model)
        {
            return View();
        }

        // FORGOTTEN PASSWORD
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // FORGOTTEN PASSWORD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
