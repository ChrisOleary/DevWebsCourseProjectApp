using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DevWebsCourseProjectApp.Models;

namespace DevWebsCourseProjectApp.Controllers
{
    public class LoggedInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
