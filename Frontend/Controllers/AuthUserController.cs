using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class AuthUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult accountSetting()
        {
            return View();
        }

        public IActionResult forgetPassword()
        {
            return View();
        }
        public IActionResult signIn()
        {
            return View();
        }
        public IActionResult signUp()
        {
            return View();
        }
    }
}
