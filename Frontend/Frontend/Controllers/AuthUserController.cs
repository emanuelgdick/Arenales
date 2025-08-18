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
        public IActionResult signin()
        {
            return View();
        }
        public IActionResult signup()
        {
            return View();
        }
    }
}
