using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using ApiPedidos.Models;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;

namespace ApiPedidos.Controllers
{

    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    //[ApiController]
    public class ProductoController : ControllerBase
    {
        public readonly db_a6292f_pedidosContext _dbcontext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductoController(db_a6292f_pedidosContext _context, IWebHostEnvironment webHostEnvironment) 
        {
            _dbcontext = _context;
            _webHostEnvironment = webHostEnvironment;
        }

        public class ProductoEnStock
        {
            public long Id { get; set; }
            public string Descripcion { get; set; }
            public string CodigoBarras { get; set; }
            public long IdMarca { get; set; }
            public long IdRubro { get; set; }
            public decimal Precio { get; set; }
            public string? Imagen { get; set; }
            public decimal Cantidad { get; set; }
            
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista() { 
            List<Producto> lista = new List<Producto>();

            try
            {
                lista = _dbcontext.Productos.Include(c => c.oRubro).Include(d=>d.oMarca).ToList();
                var ProductoEnStock = new List<ProductoEnStock>();
                using (var ctx = new db_a6292f_pedidosContext())
                {
                    var query = from p in ctx.Productos
                                join ps in ctx.ProductoStocks on p.Id equals ps.IdProducto
                                select new ProductoEnStock
                                {
                                    Id = p.Id,
                                    Descripcion = p.Descripcion,
                                    CodigoBarras = p.CodigoBarras,
                                    IdMarca=p.IdMarca,
                                    IdRubro = p.IdRubro,
                                    Precio = p.Precio,
                                    Imagen = p.Imagen,
                                    Cantidad = ps.Cantidad
                                };

                    ProductoEnStock = query.ToList();
                }
                


                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = ProductoEnStock });
            }
            catch (Exception ex) {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }

        [HttpGet]
        [Route("Obtener/{idProducto:int}")]
        public IActionResult Obtener(long idProducto)
        {
            List<Producto> oProducto = _dbcontext.Productos.Where(s => s.Id == idProducto).ToList();

            if (oProducto == null)
            {
                return BadRequest("Producto no encontrada");

            }

            try
            {

                oProducto = _dbcontext.Productos.Where(p => p.Id == idProducto).ToList();//.FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oProducto });
                // return StatusCode(StatusCodes.Status200OK, new { oRubro });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oProducto });

            }
        }

        [HttpGet]
        [Route("ObtenerProductoPorRubro/{idRubro:int}")]
        public IActionResult ObtenerProductoPorRubro(long idRubro)
        {
            List<Producto> oProducto = _dbcontext.Productos.Where(s => s.IdRubro == idRubro).ToList();

            if (oProducto == null)
            {
                return BadRequest("Producto no encontrada");

            }

            try
            {

                oProducto = _dbcontext.Productos.Where(p => p.IdRubro == idRubro).ToList();//.FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oProducto });
                // return StatusCode(StatusCodes.Status200OK, new { oRubro });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oProducto });

            }
        }

        [HttpDelete]
        [Route("Eliminar/{idProducto:int}")]
        public IActionResult Eliminar(long idProducto)
        {

            Producto oProducto = _dbcontext.Productos.Find(idProducto);

            if (oProducto == null)
            {
                return BadRequest("Producto no encontrado");

            }

            try
            {

                _dbcontext.Productos.Remove(oProducto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }


        }

        [HttpPost, Route("subirDocumento")]
        public ActionResult subirDocumento([FromForm] IFormFile fichero)
        {
            try
            {
                // Obtener ruta de destino
                string rutaDestino = _webHostEnvironment.ContentRootPath + "\\FicherosSubidos";
                if (!Directory.Exists(rutaDestino)) Directory.CreateDirectory(rutaDestino);
                string rutaDestinoCompleta = Path.Combine(rutaDestino, fichero.FileName);

                // Se valida si la variable "fichero" tiene algún archivo
                if (fichero.Length > 0)
                {
                    // Se crea una variable FileStream para cargarlo en la ruta definida
                    using (var stream = new FileStream(rutaDestinoCompleta, FileMode.Create))
                    {
                        fichero.CopyTo(stream);
                    }
                }

                // Respuesta
                return Ok("El documento se ha subido correctamente.");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("bajarDocumento")]
        public ActionResult BajarDocumento([FromForm] string nombreFichero)
        {
            try
            {
                string rutaDestino = _webHostEnvironment.ContentRootPath + "/Imagenes";
                string rutaDestinoCompleta = Path.Combine(rutaDestino, nombreFichero);
                byte[] bytes = System.IO.File.ReadAllBytes(rutaDestinoCompleta);
                return File(bytes, "application/octet-stream", nombreFichero);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<Producto> Editar([FromBody] Producto objeto)
        {
            Producto oProducto = _dbcontext.Productos.Find(objeto.Id);


            Producto r = new Producto();
            oProducto.Descripcion = objeto.Descripcion is null ? oProducto.Descripcion : objeto.Descripcion;
            oProducto.Codigo = objeto.Codigo is null ? oProducto.Codigo : objeto.Codigo;
            oProducto.Imagen = "Images/Productos/" + oProducto.Id.ToString() + ".webp";


            _dbcontext.Productos.Update(oProducto);
            _dbcontext.SaveChanges();
            r = _dbcontext.Productos.Where(s => s.Id == objeto.Id).FirstOrDefault();
            return r;

        }

        [HttpPost]
        [Route("Guardar")]

        public async Task<Producto> Guardar([FromBody] Producto producto)
        {
            Producto r = new Producto();
            long id = 0;
            _dbcontext.Productos.Add(producto);
            _dbcontext.SaveChanges();
            id = _dbcontext.Productos.OrderByDescending(u => u.Id).FirstOrDefault().Id;
            _dbcontext.Productos.Where(s => s.Id == id).FirstOrDefault().Imagen = "Images/Productos/" + id.ToString() + ".webp";
            _dbcontext.SaveChanges();
            r = _dbcontext.Productos.OrderByDescending(u => u.Id).FirstOrDefault();

            return r;
        }

        [HttpPost("GuardarImagen")]
        public async Task<string> GuardarImagen([FromForm] subirImagenApi archivo)
        {
            var ruta = String.Empty;
            if (archivo.Archivo.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\Productos\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\Productos\\");
                    }
                    var str = _webHostEnvironment.WebRootPath + "\\Images\\Productos\\" + archivo.Archivo.FileName;

                    if (System.IO.File.Exists(str))
                    {
                        System.IO.File.Delete(str);
                    }

                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Images\\Productos\\" + archivo.Archivo.FileName))
                    {
                        archivo.Archivo.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\Images\\Productos\\" + archivo.Archivo.FileName;
                    }
                }
                catch { }
            }
            return ruta;
        }

    }
}
