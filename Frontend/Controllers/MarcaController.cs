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
    public class MarcaController : Controller
    {
        private readonly MarcaService _MarcaService;
        private readonly IConfiguration _config;

        public MarcaController(IConfiguration config)
        {
            _MarcaService = new MarcaService();
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
            //   totales = await _MarcaService.GetTotales(int.Parse(userId), HttpContext.Session.GetString("APIToken"));
            return View(/*totales*/);

        }


        //[Authorize(Roles = "Admin")]
        //[ResponseCache(Duration = 30)]
        public async Task<JsonResult> GetAllMarcas(string? q = null)
        {
            //List<Marca> oLista = new List<Marca>();
            //oLista = await _apiService.GetAllMarcas(HttpContext.Session.GetString("APIToken"));
            //return Json(new { data = oLista });

            List<Marca> oLista = new List<Marca>();
            oLista = await _MarcaService.GetAllMarcas(/*HttpContext.Session.GetString("APIToken")*/);
            List<Marca> resultados = new List<Marca>();
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
        public async Task<JsonResult> CreateMarca([FromBody] Marca Marca)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (Marca.Id == 0)
                {
                    if (Marca.Descripcion != "")
                    {
                        Marca = await _MarcaService.AddMarca(Marca, HttpContext.Session.GetString("APIToken"));
                        resultado = Marca.Id;
                        mensaje = "Marca ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
                else
                {
                    if (Marca.Descripcion != "")
                    {
                        await _MarcaService.UpdateMarca(Marca.Id, Marca, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Marca modificado correctamente";
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

            Marca Marca = new Marca();
            Marca = await _MarcaService.GetMarcaById(id, HttpContext.Session.GetString("APIToken"));
            return View(Marca);
        }


        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Delete(int id)
        {

            Marca Marca = new Marca();
            Marca = await _MarcaService.GetMarcaById(id, HttpContext.Session.GetString("APIToken"));
            return View(Marca);
        }

        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]

        public async Task<JsonResult> DeleteMarca([FromBody] Marca Marca)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _MarcaService.DeleteMarca(Marca.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Marca eliminado correctamente";
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
