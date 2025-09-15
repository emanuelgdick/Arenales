using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult ShoppingCart()
        {
            return View();
        }


        public IActionResult ProductDetails()
        {

            return View();
        }


      

        public IActionResult CheckOut() {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"); // Reemplaza "id_usuario" con el nombre de tu claim
            if (userIdClaim != null)
            {
                string idUsuario = userIdClaim.Value;
                ViewBag.idUsuario = idUsuario;
            }
            return View();
        }
    }
}
