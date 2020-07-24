using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevWebsCourseProjectApp.ViewComponents
{
    public class LoginViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
