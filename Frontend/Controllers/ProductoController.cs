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

namespace FrontEnd.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoService _ProductoService;
        private readonly IConfiguration _config;

        public ProductoController(IConfiguration config)
        {
            _ProductoService = new ProductoService();
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
            //   totales = await _ProductoService.GetTotales(int.Parse(userId), HttpContext.Session.GetString("APIToken"));
            return View(totales);

        }


        //[Authorize(Roles = "Admin")]
        //[ResponseCache(Duration = 30)]
        public async Task<JsonResult> GetAllProductos(string? q = null)
        {
            //List<Producto> oLista = new List<Producto>();
            //oLista = await _apiService.GetAllProductos(HttpContext.Session.GetString("APIToken"));
            //return Json(new { data = oLista });

            List<Producto> oLista = new List<Producto>();
            oLista = await _ProductoService.GetAllProductos(/*HttpContext.Session.GetString("APIToken")*/);
            List<Producto> resultados = new List<Producto>();
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
        public async Task<JsonResult> CreateProducto([FromBody] Producto Producto)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (Producto.Id == 0)
                {
                    if (Producto.Descripcion != "")
                    {
                        Producto = await _ProductoService.AddProducto(Producto, HttpContext.Session.GetString("APIToken"));
                        resultado = Producto.Id;
                        mensaje = "Producto ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese la Descripción";
                    }
                }
                else
                {
                    if (Producto.Descripcion != "")
                    {
                        await _ProductoService.UpdateProducto(Producto.Id, Producto, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "Producto modificado correctamente";
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

            Producto Producto = new Producto();
            Producto = await _ProductoService.GetProductoById(id, HttpContext.Session.GetString("APIToken"));
            return View(Producto);
        }


        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Delete(int id)
        {

            Producto Producto = new Producto();
            Producto = await _ProductoService.GetProductoById(id, HttpContext.Session.GetString("APIToken"));
            return View(Producto);
        }

        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]

        public async Task<JsonResult> DeleteProducto([FromBody] Producto Producto)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _ProductoService.DeleteProducto(Producto.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Producto eliminado correctamente";
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
