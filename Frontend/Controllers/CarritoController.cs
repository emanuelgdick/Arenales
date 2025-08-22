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
    public class CarritoController : Controller
    {
        private readonly CarritoService _CarritoService;
        private readonly IConfiguration _config;

        public CarritoController(IConfiguration config)
        {
            _CarritoService = new CarritoService();
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
            //   totales = await _CarritoService.GetTotales(int.Parse(userId), HttpContext.Session.GetString("APIToken"));
            return View(totales);

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


        //[Authorize(Roles = "Admin")]
        //[ResponseCache(Duration = 30)]
     
        public async Task<JsonResult> GetCarritoByCliente(long idCliente)
        {
            Carrito oLista = new Carrito();
            oLista = await _CarritoService.GetCarritoByCliente(idCliente/*,HttpContext.Session.GetString("APIToken")*/);
            var carrito = new List<Carrito>
            {
                new Carrito {
                            Id = 1,
                            Fecha = DateTime.Parse("29-09-1978"),
                            Total=10000,
                            Nro=1,
                            IdCliente=1,
                            IdVendedor=1,
                            CarritoItems =new List<CarritoItem>{
                                new CarritoItem{Id = 1, IdCarrito = 1, IdProducto = 1 ,Punitario = 10,Cantidad=10,
                                       /* oProducto=new Producto{Id =1,Descripcion="aaaa",Imagen="" }*/ },
                                new CarritoItem{Id = 2, IdCarrito = 1, IdProducto = 2 ,Punitario = 20,Cantidad=20},
                                new CarritoItem{Id = 3, IdCarrito = 1, IdProducto = 3 ,Punitario = 30,Cantidad=30}
                            }


                },
                new Carrito {
                            Id = 2,
                            Fecha = DateTime.Parse("22-01-2010"),
                            Total=20000,
                            Nro=2,
                            IdCliente=2,
                            IdVendedor=2,
                            CarritoItems =new List<CarritoItem>{
                                new CarritoItem{Id = 4, IdCarrito = 2, IdProducto = 4 ,Punitario = 40,Cantidad=40},
                                new CarritoItem{Id = 5, IdCarrito = 2, IdProducto = 5 ,Punitario = 50,Cantidad=50},
                                new CarritoItem{Id = 6, IdCarrito = 2, IdProducto = 6 ,Punitario = 60,Cantidad=60}
                            }


                },
                new Carrito {
                            Id = 3,
                            Fecha = DateTime.Parse("04-10-1950"),
                            Total=30000,
                            Nro=3,
                            IdCliente=3,
                            IdVendedor=3,
                            CarritoItems =new List<CarritoItem>{
                                new CarritoItem{Id = 7, IdCarrito = 3, IdProducto = 7 ,Punitario = 70,Cantidad=70},
                                new CarritoItem{Id = 8, IdCarrito = 3, IdProducto = 8 ,Punitario = 80,Cantidad=80},
                                new CarritoItem{Id = 9, IdCarrito = 3, IdProducto = 9 ,Punitario = 90,Cantidad=90}
                            }
                }
            };
            return Json(new { data = carrito });
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


        //[Authorize(Roles = "Admin")]
        //[ResponseCache(Duration = 30)]
        public async Task<JsonResult> AddProductoCarrito([FromBody] Producto producto)
        {
            object resultado;
            string mensaje = String.Empty;
            try
            {
                if (producto.Id == 0)
                {
            //        producto = await _CarritoService.AddProductoCarrito(producto/*, HttpContext.Session.GetString("APIToken")*/);
                    resultado = producto.Id;
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
