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
    public class RubroController : ControllerBase
    {
        public readonly db_a6292f_pedidosContext _dbcontext;

        private static IWebHostEnvironment _webHostEnvironment;


        public RubroController(db_a6292f_pedidosContext _context, IWebHostEnvironment webHostEnvironment)
        {
            _dbcontext = _context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Rubro> lista = new List<Rubro>();

            try
            {
                lista = _dbcontext.Rubros.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }

        [HttpGet]
        [Route("Obtener/{idRubro:int}")]
        public IActionResult Obtener(long idRubro)
        {
            List<Rubro> oRubro = _dbcontext.Rubros.Where(s => s.Id == idRubro).ToList();

            if (oRubro == null)
            {
                return BadRequest("Rubro no encontrada");

            }

            try
            {

                oRubro = _dbcontext.Rubros.Where(p => p.Id == idRubro).ToList();//.FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oRubro });
                // return StatusCode(StatusCodes.Status200OK, new { oRubro });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oRubro });


            }
        }

        [HttpDelete]
        [Route("Eliminar/{idRubro:int}")]
        public IActionResult Eliminar(long idRubro)
        {

            Rubro oRubro = _dbcontext.Rubros.Find(idRubro);

            if (oRubro == null)
            {
                return BadRequest("Rubro no encontrado");

            }

            try
            {
                _dbcontext.Rubros.Remove(oRubro);
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
        public async Task<Rubro> Editar([FromBody] Rubro objeto)
        {
            Rubro oRubro = _dbcontext.Rubros.Find(objeto.Id);


            Rubro r = new Rubro();
            oRubro.Descripcion = objeto.Descripcion is null ? oRubro.Descripcion : objeto.Descripcion;
            oRubro.Codigo = objeto.Codigo is null ? oRubro.Codigo : objeto.Codigo;
            oRubro.Imagen = "Images/Rubros/" + oRubro.Id.ToString() + ".webp";


            _dbcontext.Rubros.Update(oRubro);
            _dbcontext.SaveChanges();
            r = _dbcontext.Rubros.Where(s=>s.Id==objeto.Id).FirstOrDefault();
            return r;

        }

        [HttpPost]
        [Route("Guardar")]
        
        public async  Task<Rubro> Guardar( [FromBody] Rubro rubro)
        {
                 Rubro r = new Rubro();
                long id = 0;   
                _dbcontext.Rubros.Add(rubro);
          
                _dbcontext.SaveChanges();
                id = _dbcontext.Rubros.OrderByDescending(u => u.Id).FirstOrDefault().Id;
                _dbcontext.Rubros.Where(s => s.Id == id).FirstOrDefault().Imagen = "Images/Rubros/" + id.ToString() + ".webp";
                _dbcontext.SaveChanges();
                r = _dbcontext.Rubros.OrderByDescending(u => u.Id).FirstOrDefault();

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
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\Rubros\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\Rubros\\");
                    }
                    var str = _webHostEnvironment.WebRootPath + "\\Images\\Rubros\\" + archivo.Archivo.FileName;

                    if (System.IO.File.Exists(str))
                    {
                        System.IO.File.Delete(str);
                    }

                    using ( FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Images\\Rubros\\" + archivo.Archivo.FileName))
                    {
                        archivo.Archivo.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\Images\\Rubros\\" +archivo.Archivo.FileName;
                    }
                }
                catch { }
            }
            return ruta;
        }
    }
  
}
