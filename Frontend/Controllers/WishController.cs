using Frontend.Models;
using Frontend.Services;
using Frontend.Models;
//using Frontend.Models.DTOs;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft;
using System.Security.Claims;

namespace FrontEnd.Controllers
{
    public class WishController : Controller
    {
        private readonly WishService _WishService;
        private readonly IConfiguration _config;

        public WishController(IConfiguration config)
        {
            _WishService = new WishService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string userId = string.Empty;
            if (userIdClaim != null)
            {
                userId = userIdClaim.Value;
            }
            // TotalesDTO totales = new TotalesDTO();
            //   totales = await _WishService.GetTotales(int.Parse(userId), HttpContext.Session.GetString("APIToken"));
            return View(/*totales*/);

        }


        //[Authorize(Roles = "Admin")]
        //[ResponseCache(Duration = 30)]
        public async Task<JsonResult> GetAllWishs()
        {
            //List<Wish> oLista = new List<Wish>();
            //oLista = await _apiService.GetAllWishs(HttpContext.Session.GetString("APIToken"));
            //return Json(new { data = oLista });

            List<Wish> oLista = new List<Wish>();
            oLista = await _WishService.GetAllWishes(HttpContext.Session.GetString("APIToken"));
            List<Wish> resultados = new List<Wish>();
            resultados = oLista.ToList();
            return Json(new { data = resultados });
        }


        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        public async Task<JsonResult> GetWishByUsuario(long idUsuario)
        {
            List<Wish> oLista = new List<Wish>();
            oLista = await _WishService.GetWishByUsuario(idUsuario, HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }



        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<JsonResult> CreateWish(long idUsuario,[FromBody] Wish wish)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
               wish = await _WishService.AddWish(wish, HttpContext.Session.GetString("APIToken"));
               resultado = wish.Id;
               mensaje = "Wish ingresado correctamente";
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje += ex.Message;
            }
            return Json(new { resultado = resultado, mensaje = mensaje });
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Details(int id)
        {

            Wish Wish = new Wish();
            Wish = await _WishService.GetWishById(id, HttpContext.Session.GetString("APIToken"));
            return View(Wish);
        }


        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Delete(int id)
        {

            Wish Wish = new Wish();
            Wish = await _WishService.GetWishById(id, HttpContext.Session.GetString("APIToken"));
            return View(Wish);
        }

        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]

        public async Task<JsonResult> DeleteWish([FromBody] Wish Wish)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _WishService.DeleteWish(Wish, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Wish eliminado correctamente";
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje += ex.Message;

            }
            return Json(new { resultado = resultado, mensaje = mensaje });
        }

        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
