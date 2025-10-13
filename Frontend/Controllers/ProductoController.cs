using Frontend.Models;
using Frontend.Services;
using Frontend.Models;
//using Frontend.Models.DTOs;
using Frontend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;

namespace FrontEnd.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoService _ProductoService;
        private readonly TalleService _TalleService;
        private readonly ColorService _ColorService;
        private readonly IConfiguration _config;

        public ProductoController(IConfiguration config)
        {
            _ProductoService = new ProductoService();
            _TalleService = new TalleService();
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
            //TotalesDTO totales = new TotalesDTO();
            //   totales = await _ProductoService.GetTotales(int.Parse(userId), HttpContext.Session.GetString("APIToken"));
            return View(/*totales*/);

        }


        public class aTalles
        {
            public string codigo { get; set; }
            public Talle[] talle { get; set; }
        }

        public class aColores
        {
            public string codigo { get; set; }
            //public string[] IdColor { get; set; }
            //public string[] Descripcion { get; set; }
            public Color[] color { get; set; }
        }


        //[Authorize(Roles = "Admin")]
        //[ResponseCache(Duration = 30)]
        public async Task<JsonResult> GetAllProductos(string? q = null)
        {
            IEnumerable<Producto> oLista = new List<Producto>();
            oLista = await _ProductoService.GetAllProductos(HttpContext.Session.GetString("APIToken"));
            List<Producto> resultados = new List<Producto>();
            if (q == null || q == "null")
            {
                resultados = oLista.ToList();
            }
            else
            {
                resultados = oLista.Where(s => s.Descripcion.ToLower().Contains(q.ToLower())).ToList();
            }


            var arrayTalles = new List<aTalles>();
            var arrayColores = new List<aColores>();
            List<Producto> productos = new List<Producto>();

            IEnumerable<Talle> talle = new List<Talle>();

            for (int i = 0; i <= resultados.Count() - 1; i++)
            {
                Producto p = new Producto();
                p = resultados[i];

                List<Producto> filtro = new List<Producto>();
                filtro = resultados.Where(s => s.Codigo == p.Codigo).ToList();
                productos.Add(p);

                talle = await _TalleService.GetAllTalles(/*HttpContext.Session.GetString("APIToken")*/);
                Talle[] arrayT = new Talle[filtro.Count];
                int j = 0;
                
                while (j < filtro.Count())
                {
                        arrayT[j] = talle.Where(s => s.Id == filtro[j].IdTalle).FirstOrDefault();
                
                 j++;
                }
                i = i + j - 1;
                
                arrayTalles.Add(new aTalles { codigo = p.Codigo, talle = arrayT });

                IEnumerable<Color> color = new List<Color>();
                color = await _ColorService.GetAllColores(HttpContext.Session.GetString("APIToken"));
                //string[] arrayC = new string[filtro.Count];
                Color[] arrayC = new Color[filtro.Count];
                int k = 0;
                while (k < filtro.Count())
                {
                    arrayC[k] = color.Where(s => s.Id == filtro[k].IdColor).FirstOrDefault();

                    k++;
                }
                //i = i + k - 1;
                arrayColores.Add(new aColores { codigo = p.Codigo, color = arrayC });

            }

           
            return Json(new { data = productos, talles = arrayTalles, colores = arrayColores });
        }



        public async Task<JsonResult> GetProductoByTCC(long talle, long color, string codigo) {

            Producto resultados = new Producto();
            resultados = await _ProductoService.GetProductoByTCC(talle,color,codigo,HttpContext.Session.GetString("APIToken"));
            
            return Json(new { data = resultados });
        }



        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        //[Authorize(Roles = "Admin")]
        //[ResponseCache(Duration = 30)]
        public async Task<JsonResult> CreateProducto([FromBody] Producto producto)
        {
            object resultado;
            string mensaje = System.String.Empty;
            try
            {
                if (producto.Id == 0)
                {
                    if (producto.Descripcion != "")
                    {
                        producto = await _ProductoService.AddProducto(producto, HttpContext.Session.GetString("APIToken"));
                        resultado = producto.Id;
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
                    if (producto.Descripcion != "")
                    {
                        await _ProductoService.UpdateProducto(producto.Id, producto, HttpContext.Session.GetString("APIToken"));

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
