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
using static System.Net.WebRequestMethods;

namespace FrontEnd.Controllers
{
    public class CarritoController : Controller
    {
        private readonly CarritoService _CarritoService;
        private readonly IConfiguration _config;

        public object CarritoItems { get; private set; }

        public CarritoController(IConfiguration config)
        {
            _CarritoService = new CarritoService();
            _config = config;
        }

        //[Authorize(Roles = "Admin")]
        //[ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string userId = string.Empty;
            if (userIdClaim != null)
            {
                userId = userIdClaim.Value;
            }
           // TotalesDTO totales = new TotalesDTO();
            //   totales = await _CarritoService.GetTotales(int.Parse(userId), HttpContext.Session.GetString("APIToken"));
            return View(/*totales*/);

        }


        //[Authorize(Roles = "Admin")]
        //[ResponseCache(Duration = 30)]
        //public async Task<JsonResult> GetAllCarritos(string? q = null)
        //{
        //    //List<Carrito> oLista = new List<Carrito>();
        //    //oLista = await _apiService.GetAllCarritos(HttpContext.Session.GetString("APIToken"));
        //    //return Json(new { data = oLista });

        //    List<Carrito> oLista = new List<Carrito>();
        //    oLista = await _CarritoService.GetAllCarritos(/*HttpContext.Session.GetString("APIToken")*/);
        //    List<Carrito> resultados = new List<Carrito>();
        //    if (q == null || q == "null")
        //    {
        //        resultados = oLista.ToList();

        //        //return Json(new { data = resultados.Select(c => new { id = c.Id, text = c.Descripcion }) });
        //    }
        //    else
        //    {
        //        resultados = oLista.Where(s => s.Descripcion.ToLower().Contains(q.ToLower())).ToList();
        //        //return Json(new { data = resultados.Select(c => new { id = c.Id, text = c.Descripcion }).ToList() });
        //    }

        //    return Json(new { data = resultados });
        //}


        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]

        public async Task<JsonResult> GetCarritoByCliente(long idCliente)
        {
            Carrito oLista = new Carrito();
            oLista = await _CarritoService.GetCarritoByCliente(idCliente,HttpContext.Session.GetString("APIToken"));
            if (oLista != null) { 
            //foreach (CarritoProducto ci in oLista.CarritoProductos)
            //{
            //    ci.IdProductoNavigation.   .oProducto.Imagen = "http://localhost:5165/arenales/" + ci.oProducto.Imagen;
            //}
            }
            return Json(new { data = oLista });
        }


        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<JsonResult> CreateCarrito([FromBody] Carrito Carrito)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (Carrito.Id == 0)
                {
                    // Carrito = await _CarritoService.AddCarrito(Carrito, HttpContext.Session.GetString("APIToken"));
                    resultado = Carrito.Id;
                    mensaje = "Carrito ingresado correctamente";
                }
                else
                {
                    await _CarritoService.UpdateCarrito(Carrito.Id, Carrito, HttpContext.Session.GetString("APIToken"));
                    resultado = true;
                    mensaje = "Carrito modificado correctamente";
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

            Carrito Carrito = new Carrito();
            Carrito = await _CarritoService.GetCarritoById(id, HttpContext.Session.GetString("APIToken"));
            return View(Carrito);
        }


        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Delete(int id)
        {

            Carrito Carrito = new Carrito();
            Carrito = await _CarritoService.GetCarritoById(id, HttpContext.Session.GetString("APIToken"));
            return View(Carrito);
        }

        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]

        public async Task<JsonResult> DeleteCarrito([FromBody] Carrito Carrito)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _CarritoService.DeleteCarrito(Carrito.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Carrito eliminado correctamente";
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje += ex.Message;

            }
            return Json(new { resultado = resultado, mensaje = mensaje });
        }


        
        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<JsonResult> AddProductoCarrito([FromBody] CarritoProducto item, long idCliente)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (item.Id == 0)
                {
                    Carrito? tieneCarrito = await _CarritoService.TieneCarrito(idCliente, HttpContext.Session.GetString("APIToken"));
                    if (tieneCarrito == null)
                    {
                        Carrito carro = new Carrito()
                        {
                            IdCliente = idCliente,
                            Total = item.Cantidad * item.Precio,
                            Fecha = DateTime.Now,
                            Numero = 0,
                            IdEstadoCarrito = 1,
                        };
                        Carrito carrito = await _CarritoService.AddCarrito(carro, HttpContext.Session.GetString("APIToken"));
                        item.IdCarrito = carrito.Id;
                    }
                    else {
                       item.IdCarrito = tieneCarrito.Id;
                    }

                    await _CarritoService.AddProductoCarrito(item, HttpContext.Session.GetString("APIToken"));

                    resultado = true;
                    mensaje = "Producto ingresado correctamente";
                }
                else
                {
                    //    await _CarritoService.UpdateProductoCarrito(producto.Id, producto/*, HttpContext.Session.GetString("APIToken")*/);
                    resultado = true;
                    mensaje = "Producto modificado correctamente";
                }
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
