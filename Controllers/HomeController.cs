using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DevWebsCourseProjectApp.Models;
using DevWebsCourseProjectApp.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DevWebsCourseProjectApp.Services;

namespace DevWebsCourseProjectApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSend _emailSend;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSend emailSend)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSend = emailSend;
        }

        public IActionResult Index()
        {
            return View();
        }

        // LOGIN VALIDATION
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)// if vallidation passes
            {
                var loginResults = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure:false);
                if (loginResults.Succeeded)
                {
                    return RedirectToAction("Index", "LoggedIn");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Info!");
                    return View(model);
                }
            }
            return View(model);
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
            if (ModelState.IsValid) // if user has filled out correct info to register from home/register
            {
                // create new user
                var identityUser = new ApplicationUser {
                    UserName = model.Username,
                    Email = model.Username // for now set username and email to be email address
                };

                var identityResults = await _userManager.CreateAsync(identityUser, model.Password);
                if (identityResults.Succeeded)
                {
                    // log user in
                    await _signInManager.SignInAsync(identityUser, isPersistent: false); // isPersistent:false = cookies NOT persistent after browser close
                    // take to login page
                    return RedirectToAction("Index", "LoggedIn");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error in creating user.");
                    return View(model);
                }
            }

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
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // find users account
                var user = await _userManager.FindByEmailAsync(model.Email);
                // if there is no account
                if (user == null)
                {
                    // redirect to login
                    return RedirectToAction("Index", "Home");
                }
                // if there is an account, reset password
                var code = "token";
                var result = await _userManager.ResetPasswordAsync(user, code, model.Password);
                // log in user and direct to login page
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "LoggedIn");
                }
            }
            return View(model);
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
            if (ModelState.IsValid)
            {
                // find users account
                var user = await _userManager.FindByEmailAsync(model.Email);
                // if there is no account or the forgotten password email is NOT confirmed
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user))) 
                {
                    return View("ForgotPasswordConfirmation");
                }
                // send email confirmation

            }            
           return View(model);
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        // LOG OFF
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }




        public async Task<IActionResult> TestEmail()
        {
            await _emailSend.SendEmailAsync("chris_oleary@hotmail.co.uk", "Test Email", "Some Test Text");
            
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
