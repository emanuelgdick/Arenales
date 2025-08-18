using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class ShoppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShoppingCart()
        {
            return View();
        }
    }
}
