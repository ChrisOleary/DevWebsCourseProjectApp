using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DevWebsCourseProjectApp.Models;
using DevWebsCourseProjectApp.ViewModels;

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

        // form validation
        public IActionResult Authenticate(LoginViewModel model)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
