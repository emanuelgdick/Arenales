using Frontend.Models;
using Frontend.Services;
using FrontEnd.Models;
using FrontEnd.Models.DTOs;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace FrontEnd.Controllers
{
    public class CarritoItemController : Controller
    {
        private readonly CarritoItemService _CarritoItemService;
        private readonly IConfiguration _config;

        public CarritoItemController(IConfiguration config)
        {
            _CarritoItemService = new CarritoItemService();
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
            TotalesDTO totales = new TotalesDTO();
            //   totales = await _CarritoItemService.GetTotales(int.Parse(userId), HttpContext.Session.GetString("APIToken"));
            return View(totales);

        }


        //[Authorize(Roles = "Admin,Student")]
        //[ResponseCache(Duration = 30)]

        public async Task<JsonResult> Delete(int id)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _CarritoItemService.DeleteCarritoItem(id/*, HttpContext.Session.GetString("APIToken")*/);
                resultado = true;
                mensaje = "Item eliminado correctamente";
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje += ex.Message;

            }
            return Json(new { resultado = resultado, mensaje = mensaje });
        }


        //[Authorize(Roles = "Admin")]
        //[ResponseCache(Duration = 30)]
        public async Task<JsonResult> Add([FromBody] CarritoItem item)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (item.Id == 0)
                {
                    item = await _CarritoItemService.AddProductoCarritoItem(item/*, HttpContext.Session.GetString("APIToken")*/);
                    resultado = item.Id;
                    mensaje = "Item ingresado correctamente";
                }
                else
                {
                    await _CarritoItemService.UpdateProductoCarritoItem(item.Id, item/*, HttpContext.Session.GetString("APIToken")*/);
                    resultado = true;
                    mensaje = "Item modificado correctamente";
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje += ex.Message;
            }
            return Json(new { resultado = resultado, mensaje = mensaje });
        }

    
    }
}
