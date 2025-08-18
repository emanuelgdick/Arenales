using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using ApiPedidos.Models;

using Microsoft.AspNetCore.Cors;

namespace ApiPedidos.Controllers
{

    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        public readonly db_a6292f_pedidosContext _dbcontext;

        private static IWebHostEnvironment _webHostEnvironment;
        public MarcaController(db_a6292f_pedidosContext _context, IWebHostEnvironment webHostEnvironment)
        {
            _dbcontext = _context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Marca> lista = new List<Marca>();

            try
            {
                lista = _dbcontext.Marcas.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }


        [HttpGet]
        [Route("Obtener/{idMarca:int}")]
        public IActionResult Obtener(long idMarca)
        {
            List<Marca> oMarca = _dbcontext.Marcas.Where(s => s.Id == idMarca).ToList();

            if (oMarca == null)
            {
                return BadRequest("Marca no encontrada");

            }

            try
            {

                oMarca = _dbcontext.Marcas.Where(p => p.Id == idMarca).ToList();//.FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oMarca });
                // return StatusCode(StatusCodes.Status200OK, new { oRubro });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oMarca });


            }
        }


        [HttpDelete]
        [Route("Eliminar/{idMarca:int}")]
        public IActionResult Eliminar(long idMarca)
        {

            Marca oMarca = _dbcontext.Marcas.Find(idMarca);

            if (oMarca == null)
            {
                return BadRequest("Marca no encontrada");

            }

            try
            {

                _dbcontext.Marcas.Remove(oMarca);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }




        [HttpPut]
        [Route("Editar")]
        public async Task<Marca> Editar([FromBody] Marca objeto)
        {
            Marca oMarca = _dbcontext.Marcas.Find(objeto.Id);


            Marca r = new Marca();
            oMarca.Descripcion = objeto.Descripcion is null ? oMarca.Descripcion : objeto.Descripcion;
            oMarca.Imagen = "Images/Marcas/" + oMarca.Id.ToString() + ".webp";


            _dbcontext.Marcas.Update(oMarca);
            _dbcontext.SaveChanges();
            r = _dbcontext.Marcas.Where(s => s.Id == objeto.Id).FirstOrDefault();
            return r;

        }

        [HttpPost]
        [Route("Guardar")]

        public async Task<Marca> Guardar([FromBody] Marca marca)
        {
            Marca r = new Marca();
            long id = 0;
            _dbcontext.Marcas.Add(marca);
            _dbcontext.SaveChanges();
            id = _dbcontext.Marcas.OrderByDescending(u => u.Id).FirstOrDefault().Id;
            _dbcontext.Marcas.Where(s => s.Id == id).FirstOrDefault().Imagen = "Images/Marcas/" + id.ToString() + ".webp";
            _dbcontext.SaveChanges();
            r = _dbcontext.Marcas.OrderByDescending(u => u.Id).FirstOrDefault();

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
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\Marcas\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\Marcas\\");
                    }
                    var str = _webHostEnvironment.WebRootPath + "\\Images\\Marcas\\" + archivo.Archivo.FileName;

                    if (System.IO.File.Exists(str))
                    {
                        System.IO.File.Delete(str);
                    }

                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Images\\Marcas\\" + archivo.Archivo.FileName))
                    {
                        archivo.Archivo.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\Images\\Marcas\\" + archivo.Archivo.FileName;
                    }
                }
                catch { }
            }
            return ruta;
        }
    }
}
