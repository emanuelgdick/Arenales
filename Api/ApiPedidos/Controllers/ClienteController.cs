using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using ApiPedidos.Models;

using Microsoft.AspNetCore.Cors;

namespace ApiPedidos.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    //[ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly db_a6292f_pedidosContext _dbcontext;

        private static IWebHostEnvironment _webHostEnvironment;
        public ClienteController(db_a6292f_pedidosContext _context, IWebHostEnvironment webHostEnvironment)
        {
            _dbcontext = _context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Cliente> lista = new List<Cliente>();

            try
            {
                lista = _dbcontext.Clientes.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }

     
     
         
        [HttpGet]
        [Route("Obtener/{idCliente:int}")]
        public IActionResult Obtener(long idCliente)
        {
            List<Cliente> oCliente = _dbcontext.Clientes.Where(s => s.Id == idCliente).ToList();

            if (oCliente == null)
            {
                return BadRequest("Cliente no encontrada");

            }

            try
            {

                oCliente = _dbcontext.Clientes.Where(p => p.Id == idCliente).ToList();//.FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oCliente });
                // return StatusCode(StatusCodes.Status200OK, new { oRubro });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oCliente });


            }
        }
         


        [HttpDelete]
        [Route("Eliminar/{idCliente:int}")]
        public IActionResult Eliminar(long idCliente)
        {

            Cliente oCliente = _dbcontext.Clientes.Find(idCliente);

            if (oCliente == null)
            {
                return BadRequest("Cliente no encontrada");

            }

            try
            {

                _dbcontext.Clientes.Remove(oCliente);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }


        [HttpPut]
        [Route("Editar")]
        public async Task<Cliente> Editar([FromBody] Cliente objeto)
        {
            Cliente oCliente = _dbcontext.Clientes.Find(objeto.Id);


            Cliente r = new Cliente();
            oCliente.Apellido = objeto.Apellido == null ? "" : objeto.Apellido;

            oCliente.Imagen = "Images/Clientes/" + oCliente.Id.ToString() + ".webp";


            _dbcontext.Clientes.Update(oCliente);
            _dbcontext.SaveChanges();
            r = _dbcontext.Clientes.Where(s => s.Id == objeto.Id).FirstOrDefault();
            return r;

        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<Cliente> Guardar([FromBody] Cliente cliente)
        {
            Cliente r = new Cliente();
            long id = 0;
            _dbcontext.Clientes.Add(cliente);
            _dbcontext.SaveChanges();
            id = _dbcontext.Clientes.OrderByDescending(u => u.Id).FirstOrDefault().Id;
            _dbcontext.Clientes.Where(s => s.Id == id).FirstOrDefault().Imagen = "Images/Clientes/" + id.ToString() + ".webp";
            _dbcontext.SaveChanges();
            r = _dbcontext.Clientes.OrderByDescending(u => u.Id).FirstOrDefault();

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
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\Clientes\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\Clientes\\");
                    }
                    var str = _webHostEnvironment.WebRootPath + "\\Images\\Clientes\\" + archivo.Archivo.FileName;

                    if (System.IO.File.Exists(str))
                    {
                        System.IO.File.Delete(str);
                    }

                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Images\\Clientes\\" + archivo.Archivo.FileName))
                    {
                        archivo.Archivo.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\Images\\Clientes\\" + archivo.Archivo.FileName;
                    }
                }
                catch { }
            }
            return ruta;
        }

    }
}
