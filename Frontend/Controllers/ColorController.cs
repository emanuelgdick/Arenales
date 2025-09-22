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
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;

namespace FrontEnd.Controllers
{
    public class ColorController : Controller
    {
        private readonly ColorService _ColorService;
        private readonly IConfiguration _config;

        public ColorController(IConfiguration config)
        {
            _ColorService = new ColorService();
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
            //   totales = await _ColorService.GetTotales(int.Parse(userId), HttpContext.Session.GetString("APIToken"));
            return View(/*totales*/);

        }


        //[Authorize(Roles = "Admin")]
        //[ResponseCache(Duration = 30)]
        public async Task<JsonResult> GetAllColores(string? q = null)
        {
            //List<Color> oLista = new List<Color>();
            //oLista = await _apiService.GetAllColors(HttpContext.Session.GetString("APIToken"));
            //return Json(new { data = oLista });

            List<Color> oLista = new List<Color>();
            oLista = await _ColorService.GetAllColores(HttpContext.Session.GetString("APIToken"));
            List<Color> resultados = new List<Color>();
            if (q == null || q == "null")
            {
                resultados = oLista.ToList();

                //return Json(new { data = resultados.Select(c => new { id = c.Id, text = c.Descripcion }) });
            }
            else
            {
                resultados = oLista.Where(s => s.Descripcion.ToLower().Contains(q.ToLower())).ToList();
                //return Json(new { data = resultados.Select(c => new { id = c.Id, text = c.Descripcion }).ToList() });
            }

            return Json(new { data = resultados });
        }








        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<JsonResult> CreateColor([FromBody] Color Color)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (Color.Id == 0)
                {
                    if (Color.Descripcion != "")
                    {
                        Color = await _ColorService.AddColor(Color, HttpContext.Session.GetString("APIToken"));
                        resultado = Color.Id;
                        mensaje = "Color ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
                else
                {
                    if (Color.Descripcion != "")
                    {
                        await _ColorService.UpdateColor(Color.Id, Color, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Color modificado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
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

            Color Color = new Color();
            Color = await _ColorService.GetColorById(id, HttpContext.Session.GetString("APIToken"));
            return View(Color);
        }


        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Delete(int id)
        {

            Color Color = new Color();
            Color = await _ColorService.GetColorById(id, HttpContext.Session.GetString("APIToken"));
            return View(Color);
        }

        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]

        public async Task<JsonResult> DeleteColor([FromBody] Color Color)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _ColorService.DeleteColor(Color.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Color eliminado correctamente";
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
